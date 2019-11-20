using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferProject.INFO;
using WaferProject.SERVER;

namespace WaferProject.DB
{
    class Database
    {
        private static string strConn = "SERVER=220.69.249.224; DATABASE=wafer_database; UID=moon; PASSWORD=wogjs30702;";

        /* 자동으로 공정이 흘러가도록 (미구현) */

        /* 날짜가 지나면 CreateDate 들 COUNT UP (미구현) */

        /* blockID 3개로 나누기 */
        public Boolean block_id_insert(string ingotId)
        {
            string[] blockId = AutoIncrement.block_num();

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into block_table values (@blockId1, @ingotId, NOW(), 0), (@blockId2, @ingotId, NOW(), 0), (@blockId3, @ingotId, NOW(), 0)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@blockId1", blockId[0]);
                    cmd.Parameters.AddWithValue("@blockId2", blockId[1]);
                    cmd.Parameters.AddWithValue("@blockId3", blockId[2]);
                    cmd.Parameters.AddWithValue("@ingotId", ingotId);


                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* block 나누기 - ingotId 가져오기 */
        public string find_block_ingot()
        {
            string ingotId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ingotId FROM ingot_table order by ingotId desc LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();


                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        
                        ingotId = res["ingotId"].ToString();

                    }
                    else
                    {
                        Console.WriteLine("데이터 없지롱");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return ingotId;
            }
        }
        /* 잉곳 생산이 끝나면 ingot 테이블 State 0으로 바꾸고 */
        public Boolean ingot_state_update(string ingotId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update ingot_table set ingotState = 1 where ingotId = @ingotId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingotId);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 잉곳 아이디 최댓값 찾기 */
        public int max_index(int count)
        {
            int max = 0;
            string query = null;

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    if (count == 1) query = "SELECT max(substring(ingotId, 8, 12)) as max_num FROM ingot_table";
                    else if (count == 2) query = "SELECT max(substring(blockId, 8, 12)) as max_num FROM block_table";
                    else if (count == 3) query = "SELECT max(substring(waferId, 8, 12)) as max_num FROM wafer_table";
                    else if (count == 4) query = "SELECT max(substring(routeId, 6, 10)) as max_num FROM route_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            max = Convert.ToInt32(res["max_num"]);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("인크리먼트 데이터가 없습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return max;
            }
        }
        /* 잉곳ID로 해당 장비 찾기 */
        public string ingot_equip_select(string ingotId)
        {
            string equip_id = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT equipId FROM ingot_table where ingotId = @ingotId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingotId);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            equip_id = res["equipId"].ToString();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잉곳의 장비 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return equip_id;
            }
        }
        /* 잉곳 종료 시간 삽입 (-> 해당 장비를 찾는다 -> 해당 장비 사용중에서 대기중으로 바꾼다) */
        public Boolean ingot_finish()
        {
            string ingotId = find_ingot_id();

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update ingot_table set ingotFinishT = NOW(), ingotState = 0 where ingotId = @ingotId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingotId);


                    if (cmd.ExecuteNonQuery() == 1 && equip_update(ingot_equip_select(ingotId)) == true)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 장비 대기중으로 만들기 (잉곳이나 웨이퍼가 완료될 시 장비를 대기중으로 만들어야하기 위함) */
        public Boolean equip_update(string equipId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update equip_table set equipState = 0 where equipId = @equipId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", equipId);
   
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 웨이퍼 생산하기 위해 블럭 정보 1개 가져오기 */
        public BlockInfo block_id_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                BlockInfo bi = new BlockInfo();
                try
                {
                    conn.Open();
                    string query = "SELECT blockId, ingotId, blockCreate FROM block_table WHERE blockState = 0 LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();


                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        
                        bi.setBlockId(res["blockId"].ToString());
                        bi.setIngotId(res["ingotId"].ToString());
                        bi.setBlockCreate(res["blockCreate"].ToString());
                    }
                    else
                    {
                        Console.WriteLine("블록 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return bi;
            }
        }
        /* 웨이퍼 생산중인거 있는지 확인 */
        public string find_ing_wafer()
        {
            string waferId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT waferId FROM wafer_table WHERE operId = 'POLISHING' AND waferFinishT IS null";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();

                        waferId = res["waferId"].ToString();
                    }
                    else
                    {
                        Console.WriteLine("진행중인 웨이퍼가 없습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return waferId;
            }
        }
        /* 웨이퍼 생산 */
        public Boolean wafer_insert(string msCode, int qty, string waferComm, string waferMaker)
        {
            /* 웨이퍼 넘버 중복 제거 */
            string wafer_name = AutoIncrement.wafer_num();
            /* 대기중인 장비 이름 */
            string equip_name = equip_ready_check_name("POLISHING");
            /* 블록 하나 가져오기 */
            BlockInfo bi = block_id_select();
            /* 블록 사용했다라고 바꾸기 */
            if (!update_block_state(bi.getBlockId()))
                return false;

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into wafer_table(waferId, blockId, ingotId, waferQuant, waferStartT, waferComm, operId, msCode, equipId, equipRpm, waferMaker) " +
                        "values (@waferId, @blockId, @ingotId, @waferQuant, NOW(), @waferComm, @operId, @msCode, @equipId, '0.5', @waferMaker )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@waferId", wafer_name);
                    cmd.Parameters.AddWithValue("@blockId", bi.getBlockId());
                    cmd.Parameters.AddWithValue("@ingotId", bi.getIngotId());
                    cmd.Parameters.AddWithValue("@waferQuant", qty);
                    cmd.Parameters.AddWithValue("@waferComm", waferComm);
                    cmd.Parameters.AddWithValue("@operId", "POLISHING");
                    cmd.Parameters.AddWithValue("@msCode", msCode);
                    cmd.Parameters.AddWithValue("@equipId", equip_name);
                    cmd.Parameters.AddWithValue("@waferMaker", waferMaker);

                    if (cmd.ExecuteNonQuery() == 1 && equip_start_state(equip_name) == true)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 웨이퍼 생산하고 블록상태 사용중으로 바꾸기 */
        public Boolean update_block_state(string blockId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update block_table set blockState = 1 where blockId = @blockId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@blockId", blockId);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1) return true;
                    else return false;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 잉곳 생산 후 장비 사용중으로 만들기 */
        public Boolean equip_start_state(string equip_name)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update equip_table set equipState = 1 where equipId = @equipId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", equip_name);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else
                    {
                        /* 장비 이벤트 등록해야 함. */

                        return true;
                    }

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 웨이퍼 생산할거 있는 확인 pi - 2번 */
        public string wafer_check()
        {
            string waferId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT waferId FROM wafer_table WHERE operId = 'POLISHING' AND waferFinishT IS null";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();


                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();

                        waferId = res["waferId"].ToString();

                    }
                    else
                    {
                        Console.WriteLine("사용자가 웨이퍼생산을 하지 않았음");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return waferId;
            }
        }
        /* 웨이퍼 높이검사 데이터 삽입 -1 mscode, equipId, waferMaker 찾기 */
        public string[] find_height_data()
        {
            string[] heightData = new string[3];
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT msCode, equipId, waferMaker FROM wafer_table WHERE operId = 'POLISHING' AND waferFinishT IS null";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();


                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();

                        heightData[0] = res["equipId"].ToString();
                        heightData[1] = res["waferMaker"].ToString();
                        heightData[2] = res["msCode"].ToString();
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 데이터 정보가 존재하지 않지롱.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return heightData;
            }
        }
        /* 웨이퍼 높이검사 데이터 삽입 -2 */
        public Boolean height_data_insert(string ttv)
        {
            randomCoord ran = new randomCoord();
            string waferId = find_ing_wafer();
            int[] coord = ran.randomPick();
            string[] height = find_height_data();
            int[] random = ran.randomData();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                //ingotId가 없으면 false
                if (waferId == null)
                    return false;

                try
                {
                    conn.Open();
                    string query = "insert into wafer_data_table values" +
                        "(@waferId, @waferPX1, @waferPY1, @waferPX2, @waferPY2, @currTtv, @currBow, @currWarp, @currThk, @msCode, @equipId, 'POLISHING', NOW(), '0.5')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@waferId", waferId);
                    cmd.Parameters.AddWithValue("@waferPX1", coord[0]);
                    cmd.Parameters.AddWithValue("@waferPX2", coord[1]);
                    cmd.Parameters.AddWithValue("@waferPY1", coord[2]);
                    cmd.Parameters.AddWithValue("@waferPY2", coord[3]);
                    cmd.Parameters.AddWithValue("@currTtv", ttv);
                    cmd.Parameters.AddWithValue("@currBow", random[0]);
                    cmd.Parameters.AddWithValue("@currWarp", random[1]);
                    cmd.Parameters.AddWithValue("@currThk", random[2]);
                    cmd.Parameters.AddWithValue("@msCode", height[2]);
                    cmd.Parameters.AddWithValue("@equipId", height[0]);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 3. 웨이퍼 폴리싱 완료 ! */
        public Boolean wafer_finish()
        {
            string waferId = find_ing_wafer();

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update wafer_table set waferFinishT = NOW(), operId = 'INVENTORY' where waferId = @waferId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@waferId", waferId);

                    if (cmd.ExecuteNonQuery() == 1 && equip_update(get_equip_wafer(waferId)) == true)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 웨이퍼 사용중인 장비id 가져오기 */
        public string get_equip_wafer(string waferId)
        {
            string equipId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT equipId FROM wafer_table WHERE waferId = @waferId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@waferId", waferId);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();

                        equipId = res["equipId"].ToString();

                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 장비정보가 없엉");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return equipId;
            }
        }
        /* 웨이퍼 넘버 중복 확인 */
        public Boolean wafer_number_check(int number)
        {
            string num = "wafer" + number.ToString();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select waferId from wafer_table where waferId = @waferId";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@waferId", num);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        /* 중복된 숫자가 있으면 False */
                        return false;
                    }
                    else
                    {
                        /* 중복된 숫자가 없으면 True */
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 잉곳 넘버 중복 확인 */
        public Boolean ingot_number_check(int number)
        {
            string num = "ingot" + number.ToString();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select ingotId from ingot_table where ingotId = @ingotId";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare(); 

                    cmd.Parameters.AddWithValue("@ingotId", num);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        /* 중복된 숫자가 있으면 False */
                        return false;
                    }
                    else
                    {
                        /* 중복된 숫자가 없으면 True */
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 장비 대기중 확인 후 장비 id 가져오기*/
        public string equip_ready_check_name(string equipType)
        {
            string equipId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select equipId from equip_table where equipType = @equipType AND equipState = 0 ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@equipType", equipType);

                    MySqlDataReader res = cmd.ExecuteReader();


                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            equipId = res["equipId"].ToString();
                            if (equipId != null)
                                return equipId;
                        }
                    }
                    else
                    {
                        Console.WriteLine("사용가능한 장비가 없습니다.");
                        return null;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return equipId;
            }
        }
        /* 잉곳 생산   ###매우 중요### */
        public Boolean ingot_create_insert(string ingot_maker)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                /* 잉곳 넘버 생산 */
                string ingot_name = AutoIncrement.ingot_num();
                /* 대기중인 장비 이름 */
                string equip_name = equip_ready_check_name("INGOT");
                if (equip_name == null)
                    return false;

                try
                {
                    conn.Open();
                    string query = "insert into ingot_table(ingotId, ingotState, ingotStartT, equipId, ingotMaker) values (@ingotId, @ingotState, NOW(), @equipId, @ingotMaker)";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingot_name);
                    cmd.Parameters.AddWithValue("@ingotState", 1);
                    cmd.Parameters.AddWithValue("@equipId", equip_name);
                    cmd.Parameters.AddWithValue("@ingotMaker", ingot_maker);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1 && equip_start_state(equip_name) == true)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 잉곳 모니터링 값 삽입 - 1 ingotstate 찾기*/
        public string find_ingot_id()
        {
            string ingotId = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select ingotId from ingot_table where ingotState = 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if(res.HasRows)
                    {
                        res.Read();
                        ingotId = res["ingotId"].ToString();
                        //Console.WriteLine("ingotId :: {0}", ingotId);
                    }
                    else
                    {
                        Console.WriteLine("진행중인 ingotId가 없습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return ingotId;
        }
        /* 잉곳 모니터링 값 삽입 -2 데이터 삽입하기 */
        public Boolean ingot_data_insert(string currTemp, string currVel, string currLen)
        {
            //ingotId 가져오기
            string ingotId = find_ingot_id();
            
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                //ingotId가 없으면 false
                if (ingotId == null)
                    return false;
                
                try
                {
                    conn.Open();
                    string query = "insert into ingot_data_table(ingotId, currTemp, currVel, currLen, currTime) values (@ingotId, @currTemp, @currVel, @currLen, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingotId);
                    cmd.Parameters.AddWithValue("@currTemp", Convert.ToDouble(currTemp));
                    cmd.Parameters.AddWithValue("@currVel", Convert.ToDouble(currVel));
                    cmd.Parameters.AddWithValue("@currLen", Convert.ToDouble(currLen));

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 잉곳 모니터링 값 삽입 -3 완료시 ingotFinishT에 업데이트 --> 위에 있길래 안썼음 (ingot_finish) */ 
        public Boolean ingot_finish_update()
        {
            //ingotId 가져오기
            string ingotId = find_ingot_id();

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update ingot_table set ingotFinishT = NOW(), ingotState = 2 where ingotId = @ingotId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingotId);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) 
                        return false;
                    else 
                        return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 잉곳 모니터링 값 삽입 -4 진행중인 잉곳의 장비이름, 잉곳maker 가져오기 */
        public string[] find_ingot_equip()
        {
            string[] name = new string[2];   //장비이름, 잉곳maker

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select equipId, ingotMaker from ingot_table where ingotState = 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        name[0] = res["equipId"].ToString();
                        name[1] = res["ingotMaker"].ToString();
                    }
                    else
                    {
                        Console.WriteLine("진행중인 잉곳이 없습니다.");
                        return name;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return name;
        }
        /* 잉곳 모니터링 값 삽입 -5 fan 장비이벤트에 삽입 */
        public Boolean fan_insert(string fanState)
        {
            string[] name = find_ingot_equip();
            string eventName = null;
            if (fanState.Equals("1"))
                eventName = "FANON";
            else if (fanState.Equals("0"))
                eventName = "FANOFF";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into equip_event_table values (@equipId, @equipEventId, 'C', NOW(), @equipState, @repairManager)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", name[0]);
                    cmd.Parameters.AddWithValue("@equipEventId", eventName);
                    cmd.Parameters.AddWithValue("@equipState", fanState);
                    cmd.Parameters.AddWithValue("@repairManager", name[1]);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine("fan 정보 삽입 성공!");
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("fan 정보 삽입 실패 ! :", e);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 잉곳 모니터링 값 삽입 -6 heat 장비이벤트에 삽입 */
        public Boolean heat_insert(string heatState)
        {
            string[] name = find_ingot_equip();
            string eventName = null;
            if (heatState.Equals("1"))
                eventName = "HEATON";
            else if(heatState.Equals("0"))
                eventName = "HEATOFF";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into equip_event_table values (@equipId, @equipEventId, 'B', NOW(), @equipState, @repairManager)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", name[0]);
                    cmd.Parameters.AddWithValue("@equipEventId", eventName);
                    cmd.Parameters.AddWithValue("@equipState", heatState);
                    cmd.Parameters.AddWithValue("@repairManager", name[1]);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine("HEAT 정보 삽입 성공 !");
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("HEAT 정보 삽입 실패 ! :", e);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* START, FINISH 장비 event 삽입 */
        public Boolean start_stop_event(string equipType, string eventId, string state)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                // ingot인지 wafer인지 췌크
                string[] name = new string[3];
                if(equipType.Equals("ingot"))
                    name = find_ingot_equip();
                else if(equipType.Equals("wafer"))
                    name = find_height_data();

                try
                {
                    conn.Open();
                    string query = "insert into equip_event_table values (@equipId, @equipEventId, 'A', NOW(), @equipState, @repairManager)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", name[0]);
                    cmd.Parameters.AddWithValue("@equipEventId", eventId);
                    cmd.Parameters.AddWithValue("@equipState", state);
                    cmd.Parameters.AddWithValue("@repairManager", name[1]);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 전체 잉곳 모니터링 */
        public List<IngotDataInfo> ingot_data_select(int count, int page)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<IngotDataInfo> list_idi = new List<IngotDataInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM ingot_data_table LIMIT @count OFFSET @num";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@num", count * (page - 1));

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            IngotDataInfo idi = new IngotDataInfo();
                            idi.setIngotId(res["ingotId"].ToString());
                            idi.setCurrTemp(Convert.ToDouble(res["currTemp"]));
                            idi.setCurrVel(Convert.ToDouble(res["currVel"]));
                            idi.setCurrLen(Convert.ToDouble(res["currLen"]));
                            idi.setCurrTime(res["currTime"].ToString());

                            list_idi.Add(idi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("잉곳 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_idi;
            }
        }
        /* 잉곳 데이터 페이징 cnt */
        public int ingot_data_cnt()
        {
            int cnt = 0;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select COUNT(*) from ingot_data_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        cnt = Convert.ToInt32(res["COUNT(*)"]);
                    }
                    else
                    {
                        Console.WriteLine("ingot데이터가 없지롱");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return cnt;
            }
        }
        /* 해당 잉곳 모니터링 */
        public List<IngotDataInfo> ingot_id_select(string ingot_id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<IngotDataInfo> list_idi = new List<IngotDataInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM ingot_data_table WHERE ingotId IN ( SELECT ingotId FROM ingot_table WHERE ingotId = @ingotId) ORDER BY currTime DESC LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@ingotId", ingot_id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        
                        IngotDataInfo idi = new IngotDataInfo();
                        idi.setIngotId(res["ingotId"].ToString());
                        idi.setCurrTemp(Convert.ToDouble(res["currTemp"]));
                        idi.setCurrVel(Convert.ToDouble(res["currVel"]));
                        idi.setCurrLen(Convert.ToDouble(res["currLen"]));
                        idi.setCurrTime(res["currTime"].ToString());

                        list_idi.Add(idi);
                    }
                    else
                    {
                        Console.WriteLine("잉곳 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_idi;
            }
        }
        /* 잉곳 관리(조회) */
        public List<IngotInfo> ingot_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<IngotInfo> list_ii = new List<IngotInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM ingot_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            IngotInfo ii = new IngotInfo();
                            ii.setIngotId(res["ingotId"].ToString());
                            ii.setIngotCreate(Convert.ToInt32(res["ingotState"]));
                            ii.setIngotStartT(res["ingotStartT"].ToString());
                            ii.setIngotFinishT(res["ingotFinishT"].ToString());
                            ii.setEquipId(res["equipId"].ToString());
                            ii.setIngotMaker(res["ingotMaker"].ToString());
                            /* 잉곳 플래그가 NULL이 아니면 에러 발생 X */
                            ii.setIngotFlag(Convert.ToInt32(res["ingotFlag"])); 

                            list_ii.Add(ii);
                        }
                    }
                    else
                    {
                        Console.WriteLine("잉곳 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ii;
            }
        }
        /* 경로 삭제 */
        public Boolean route_delete(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "delete from route_table where routeId = @routeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@routeId", id);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine(result);
                    if (result != -1) return true;
                    else return false;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 경로 추가 */
        public Boolean route_insert(string route_id, string curr_route, string next_route)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into route_table(routeId, currRoute, nextRoute) values (@routeId, @currRoute, @nextRoute)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@routeId", route_id);
                    cmd.Parameters.AddWithValue("@currRoute", curr_route);
                    cmd.Parameters.AddWithValue("@nextRoute", next_route);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1) return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 경로 id 에 따른 정보 조회2 (DATABASE JOIN) */
        public List<RouteInfo> route_id_join_select(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<RouteInfo> list_ri = new List<RouteInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT ct.codeType, ct.codeId, ct.codeAttFir, rt.currRoute " +
                        "FROM code_table AS ct, route_table AS rt " +
                        "WHERE ct.codeId = rt.currRoute AND rt.routeId = @routeId " +
                        "ORDER BY codeAttFir";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@routeId", id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            RouteInfo ri = new RouteInfo();

                            ri.setCurrRoute(res["currRoute"].ToString());

                            list_ri.Add(ri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("루트 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return list_ri;
            }
        }
        /* 경로 id 에 따른 정보 조회 */
        public List<RouteInfo> route_id_select(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<RouteInfo> list_ri = new List<RouteInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from route_table where routeId = @routeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@routeId", id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            RouteInfo ri = new RouteInfo();

                            ri.setRouteId(res["routeId"].ToString());
                            ri.setCurrRoute(res["currRoute"].ToString());
                            ri.setNextRoute(res["nextRoute"].ToString());

                            list_ri.Add(ri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("루트 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return list_ri;
            }
        }
        /* 경로 id 조회 */
        public List<RouteInfo> route_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<RouteInfo> list_ri = new List<RouteInfo>();

                try
                {
                    conn.Open();
                    string query = "select distinct routeId from route_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            RouteInfo ri = new RouteInfo();

                            ri.setRouteId(res["routeId"].ToString());

                            list_ri.Add(ri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("루트 아이디가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return list_ri;
            }
        }
        /* 제품 정보 삭제 */
        public Boolean mscode_delete(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "delete from mscode_table where msCode = @msCode";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@msCode", id);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 제품 정보 추가 */
        public Boolean mscode_insert(MsCodeInfo mi)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into mscode_table(msCode, corpName, corpComm, corpManager, routeId, msCodeCreate) values (@msCode, @corpName, @corpComm, @corpManager, @routeId, NOW())";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@msCode", mi.getMsCode());
                    cmd.Parameters.AddWithValue("@corpName", mi.getCorpName());
                    cmd.Parameters.AddWithValue("@corpComm", mi.getCorpComm());
                    cmd.Parameters.AddWithValue("@corpManager", mi.getCorpManager());
                    cmd.Parameters.AddWithValue("@routeId", mi.getRouteId());

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1) return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 제품 정보 관리(조회) */
        public List<MsCodeInfo> mscode_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<MsCodeInfo> list_mi = new List<MsCodeInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM mscode_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            MsCodeInfo mi = new MsCodeInfo();
                            mi.setMsCode(res["msCode"].ToString());
                            mi.setCorpName(res["corpName"].ToString());
                            mi.setCorpComm(res["corpComm"].ToString());
                            mi.setCorpManager(res["corpManager"].ToString());
                            mi.setRouteId(res["routeId"].ToString());
                            mi.setMsCodeCreate(res["msCodeCreate"].ToString());
                            mi.setMsCodeUpdate(res["msCodeUpdate"].ToString());

                            list_mi.Add(mi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_mi;
            }
        }
        /* 웨이퍼 측정정보 관리 (모니터링) */
        public List<WaferDataInfo> wafer_data_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<WaferDataInfo> list_wdi = new List<WaferDataInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT wdt.* FROM wafer_data_table wdt, wafer_table wt WHERE wt.waferId = wdt.waferId AND wt.waferFinishT IS NULL AND wt.operId = 'POLISHING'";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            WaferDataInfo wdi = new WaferDataInfo();
                            wdi.setWaferId(res["waferId"].ToString());
                            wdi.setWaferPX1(Convert.ToInt32(res["waferPX1"]));
                            wdi.setWaferPY1(Convert.ToInt32(res["waferPY1"]));
                            wdi.setWaferPX2(Convert.ToInt32(res["waferPX2"]));
                            wdi.setWaferPY2(Convert.ToInt32(res["waferPY2"]));
                            wdi.setCurrTtv(Convert.ToInt32(res["currTtv"]));
                            wdi.setCurrBow(Convert.ToInt32(res["currBow"]));
                            wdi.setCurrWarp(Convert.ToInt32(res["currWarp"]));
                            wdi.setCurrThk(Convert.ToInt32(res["currThk"]));
                            wdi.setMsCode(res["msCode"].ToString());
                            wdi.setEquipId(res["equipId"].ToString());
                            wdi.setOperId(res["operId"].ToString());
                            wdi.setCurrDate(res["currDate"].ToString());
                            wdi.setEquipRpm(res["equipRpm"].ToString());

                            list_wdi.Add(wdi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_wdi;
            }
        }
        /* 웨이퍼 id 별 측정정보 조회 */
        public List<WaferDataInfo> wafer_id_select(string wafer_select_data)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<WaferDataInfo> list_wdi = new List<WaferDataInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM wafer_data_table WHERE waferId IN ( SELECT waferId FROM wafer_table WHERE waferId like @waferId)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@waferId", "%" + wafer_select_data + "%");

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            WaferDataInfo wdi = new WaferDataInfo();
                            wdi.setWaferId(res["waferId"].ToString());
                            wdi.setWaferPX1(Convert.ToInt32(res["waferPX1"]));
                            wdi.setWaferPY1(Convert.ToInt32(res["waferPY1"]));
                            wdi.setWaferPX2(Convert.ToInt32(res["waferPX2"]));
                            wdi.setWaferPY2(Convert.ToInt32(res["waferPY2"]));
                            wdi.setCurrTtv(Convert.ToInt32(res["currTtv"]));
                            wdi.setCurrBow(Convert.ToInt32(res["currBow"]));
                            wdi.setCurrWarp(Convert.ToInt32(res["currWarp"]));
                            wdi.setCurrThk(Convert.ToInt32(res["currThk"]));
                            wdi.setMsCode(res["msCode"].ToString());
                            wdi.setEquipId(res["equipId"].ToString());
                            wdi.setOperId(res["operId"].ToString());
                            wdi.setCurrDate(res["currDate"].ToString());
                            wdi.setEquipRpm(res["equipRpm"].ToString());

                            list_wdi.Add(wdi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_wdi;
            }
        }
        /* 공정별 웨이퍼 데이터 검색 */
        public List<WaferDataInfo> wafer_data_operid_select(string waferOperId, int count, int page)
        {
            //int cnt = wafer_data_cnt();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<WaferDataInfo> list_wdi = new List<WaferDataInfo>();

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM wafer_data_table WHERE operId = @operId LIMIT @count OFFSET @num";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@operId", waferOperId);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@num", count*(page-1));

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            WaferDataInfo wdi = new WaferDataInfo();
                            wdi.setWaferId(res["waferId"].ToString());
                            wdi.setWaferPX1(Convert.ToInt32(res["waferPX1"]));
                            wdi.setWaferPY1(Convert.ToInt32(res["waferPY1"]));
                            wdi.setWaferPX2(Convert.ToInt32(res["waferPX2"]));
                            wdi.setWaferPY2(Convert.ToInt32(res["waferPY2"]));
                            wdi.setCurrTtv(Convert.ToInt32(res["currTtv"]));
                            wdi.setCurrBow(Convert.ToInt32(res["currBow"]));
                            wdi.setCurrWarp(Convert.ToInt32(res["currWarp"]));
                            wdi.setCurrThk(Convert.ToInt32(res["currThk"]));
                            wdi.setMsCode(res["msCode"].ToString());
                            wdi.setEquipId(res["equipId"].ToString());
                            wdi.setOperId(res["operId"].ToString());
                            wdi.setCurrDate(res["currDate"].ToString());
                            wdi.setEquipRpm(res["equipRpm"].ToString());

                            list_wdi.Add(wdi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 데이터 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_wdi;
            }
        }
        /* 공정별 웨이퍼 데이터 수 검색 (페이징) */
        public int wafer_data_cnt()
        {
            int cnt = 0;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select COUNT(*) from wafer_data_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        res.Read();
                        cnt = Convert.ToInt32(res["COUNT(*)"]);
                    }
                    else
                    {
                        Console.WriteLine("wafer데이터가 없지롱");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return cnt;
            }
        }
        /* 공정별 웨이퍼 검색 */
        public List<WaferInfo> wafer_operid_select(string wafer_oper_id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<WaferInfo> list_wi = new List<WaferInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from wafer_table where operId = @operId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@operId", wafer_oper_id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            WaferInfo wi = new WaferInfo();
                            wi.setWaferId(res["waferId"].ToString());
                            wi.setBlockId(res["blockId"].ToString());
                            wi.setIngotId(res["ingotId"].ToString());
                            wi.setWaferQuant(Convert.ToInt32(res["waferQuant"]));
                            wi.setWaferCreate(Convert.ToInt32(res["waferCreate"]));
                            wi.setWaferStartT(res["waferStartT"].ToString());
                            wi.setWaferFinishT(res["waferFinishT"].ToString());
                            wi.setWaferComm(res["waferComm"].ToString());
                            wi.setWaferFaulty(Convert.ToInt32(res["waferFaulty"]));
                            wi.setOperId(res["operId"].ToString());
                            wi.setMsCode(res["msCode"].ToString());
                            wi.setEquipId(res["equipId"].ToString());
                            wi.setEquipRpm(res["equipRpm"].ToString());
                            wi.setWaferMaker(res["waferMaker"].ToString());

                            list_wi.Add(wi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_wi;
            }
        }
        /* MSCODE로 ROUTEID 찾기 */
        public string mscode_id_select(string mscode)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                string str = null;
                List<RouteInfo> list_ri = new List<RouteInfo>();

                try
                {
                    conn.Open();
                    string query = "select routeId from mscode_table where msCode = @msCode";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@msCode", mscode);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            str = res["routeId"].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("MSCODE 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return str;
            }
        }
        /* 웨이퍼 루트 검색 */
        public List<RouteInfo> wafer_route_select(string routeId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<RouteInfo> list_ri = new List<RouteInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from route_table where routeId = @routeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@routeId", routeId);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            RouteInfo ri = new RouteInfo();
                            ri.setRouteId(res["routeId"].ToString());
                            ri.setCurrRoute(res["currRoute"].ToString());
                            ri.setNextRoute(res["nextRoute"].ToString());

                            list_ri.Add(ri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("루트 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ri;
            }
        }
        /* 웨이퍼 불량률 조회 */
        public List<FaultyInfo> wafer_faulty_select(string waferId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<FaultyInfo> list_fi = new List<FaultyInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from faulty_table where waferId = @waferId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@waferId", waferId);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            FaultyInfo fi = new FaultyInfo();
                            fi.setFaultyId(res["faultyId"].ToString());
                            fi.setFaultyQuant(Convert.ToInt32(res["faultyQuant"]));
                            fi.setFaultyCreate(res["faultyCreate"].ToString());
                            fi.setFaultyUpdate(res["faultyUpdate"].ToString());

                            list_fi.Add(fi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("불량 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_fi;
            }
        }
        /* 웨이퍼 관리 */
        public List<WaferInfo> wafer_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<WaferInfo> list_wi = new List<WaferInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from wafer_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();


                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            WaferInfo wi = new WaferInfo();
                            wi.setWaferId(res["waferId"].ToString());
                            wi.setBlockId(res["blockId"].ToString());
                            wi.setIngotId(res["ingotId"].ToString());
                            wi.setWaferQuant(Convert.ToInt32(res["waferQuant"]));
                            wi.setWaferCreate(Convert.ToInt32(res["waferCreate"]));
                            wi.setWaferStartT(res["waferStartT"].ToString());
                            wi.setWaferFinishT(res["waferFinishT"].ToString());
                            wi.setWaferComm(res["waferComm"].ToString());
                            wi.setWaferFaulty(Convert.ToInt32(res["waferFaulty"]));
                            wi.setOperId(res["operId"].ToString());
                            wi.setMsCode(res["msCode"].ToString());
                            wi.setEquipId(res["equipId"].ToString());
                            wi.setEquipRpm(res["equipRpm"].ToString());
                            wi.setWaferMaker(res["waferMaker"].ToString());

                            list_wi.Add(wi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("웨이퍼 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_wi;
            }
        }
        /* 코드 수정 */
        public Boolean code_update(CodeInfo ci)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update code_table set " +
                        "codeComm = @codeComm, codeAttFir = @codeAttFir, codeAttSec = @codeAttSec," +
                        "codeAttThr = @codeAttThr, codeAttFour = @codeAttFour, codeAttFif = @codeAttFif, codeAttSix = @codeAttSix, " +
                        "codeAttSev = @codeAttSev, codeAttEig = @codeAttEig, codeAttNin = @codeAttNin, codeAttTen = @codeAttTen, codeUpdate = NOW()" +
                        "where codeId = @codeId";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeId", ci.getCodeId());

                    cmd.Parameters.AddWithValue("@codeComm", ci.getCodeComm());
                    cmd.Parameters.AddWithValue("@codeAttFir", ci.getCodeAttFir());
                    cmd.Parameters.AddWithValue("@codeAttSec", ci.getCodeAttSec());
                    cmd.Parameters.AddWithValue("@codeAttThr", ci.getCodeAttThr());
                    cmd.Parameters.AddWithValue("@codeAttFour", ci.getCodeAttFour());
                    cmd.Parameters.AddWithValue("@codeAttFif", ci.getCodeAttFif());
                    cmd.Parameters.AddWithValue("@codeAttSix", ci.getCodeAttSix());
                    cmd.Parameters.AddWithValue("@codeAttSev", ci.getCodeAttSev());
                    cmd.Parameters.AddWithValue("@codeAttEig", ci.getCodeAttEig());
                    cmd.Parameters.AddWithValue("@codeAttNin", ci.getCodeAttNin());
                    cmd.Parameters.AddWithValue("@codeAttTen", ci.getCodeAttTen());

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1) return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        /* 코드 정보 추가 */
        public Boolean code_insert(string code_id, string code_type, string code_comm)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into code_table(codeId, codeType, codeComm, codeCreate) values (@codeId, @codeType, @codeComm, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeId", code_id);
                    cmd.Parameters.AddWithValue("@codeType", code_type);
                    cmd.Parameters.AddWithValue("@codeComm", code_comm);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 코드 삭제 */
        public Boolean code_delete(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "delete from code_table where codeId = @codeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeId", id);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine("result : {0}", result);
                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* code name 조회 */
        public List<CodeNameInfo> code_name_select(string code_select)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<CodeNameInfo> list_cni = new List<CodeNameInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from code_name_table where codeType = @codeType";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeType", code_select);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            CodeNameInfo cni = new CodeNameInfo();
                            cni.setCodeType(res["codeType"].ToString());
                            cni.setAttFirst(res["attFirst"].ToString());
                            cni.setAttSecond(res["attSecond"].ToString());
                            cni.setAttThird(res["attThird"].ToString());
                            cni.setAttFourth(res["attFourth"].ToString());
                            cni.setAttFifth(res["attFifth"].ToString());
                            cni.setAttSixth(res["attSixth"].ToString());
                            cni.setAttSeventh(res["attSeventh"].ToString());
                            cni.setAttEighth(res["attEighth"].ToString());
                            cni.setAttNinth(res["attNinth"].ToString());
                            cni.setAttTenth(res["attTenth"].ToString());

                            list_cni.Add(cni);
                        }
                    }
                    else
                    {
                        Console.WriteLine("코드 이름 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_cni;
            }
        }
        /* 코드 종류로 특정 코드 검색 */
        public List<CodeInfo> code_type_select(string code_select)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<CodeInfo> list_ci = new List<CodeInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from code_table where codeType = @codeType order by codeAttFir";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeType", code_select);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            CodeInfo ci = new CodeInfo();
                            ci.setCodeId(res["codeId"].ToString());

                            list_ci.Add(ci);
                        }
                    }
                    else
                    {
                        Console.WriteLine("코드 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ci;
            }
        }
        /* 코드ID로 특정 코드 검색 */
        public List<CodeInfo> code_view_select(string code_select)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<CodeInfo> list_ci = new List<CodeInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from code_table where codeId = @codeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@codeId", code_select);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            CodeInfo ci = new CodeInfo();
                            ci.setCodeId(res["codeId"].ToString());
                            ci.setCodeType(res["codeType"].ToString());
                            ci.setCodeComm(res["codeComm"].ToString());
                            ci.setCodeAttFir(res["codeAttFir"].ToString());
                            ci.setCodeAttSec(res["codeAttSec"].ToString());
                            ci.setCodeAttThr(res["codeAttThr"].ToString());
                            ci.setCodeAttFour(res["codeAttFour"].ToString());
                            ci.setCodeAttFif(res["codeAttFif"].ToString());
                            ci.setCodeAttSix(res["codeAttSix"].ToString());
                            ci.setCodeAttSev(res["codeAttSev"].ToString());
                            ci.setCodeAttEig(res["codeAttEig"].ToString());
                            ci.setCodeAttNin(res["codeAttNin"].ToString());
                            ci.setCodeAttTen(res["codeAttTen"].ToString());
                            ci.setCodeCreate(res["codeCreate"].ToString());
                            ci.setCodeUpdate(res["codeUpdate"].ToString());

                            list_ci.Add(ci);
                        }
                    }
                    else
                    {
                        Console.WriteLine("코드 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ci;
            }
        }
        /* 코드 관리 */
        public List<CodeNameInfo> code_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<CodeNameInfo> list_cni = new List<CodeNameInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from code_name_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            CodeNameInfo cni = new CodeNameInfo();
                            cni.setCodeType(res["codeType"].ToString());
                            cni.setAttFirst(res["attFirst"].ToString());
                            cni.setAttSecond(res["attSecond"].ToString());
                            cni.setAttThird(res["attThird"].ToString());
                            cni.setAttFourth(res["attFourth"].ToString());
                            cni.setAttFifth(res["attFifth"].ToString());
                            cni.setAttSixth(res["attSixth"].ToString());
                            cni.setAttSeventh(res["attSeventh"].ToString());
                            cni.setAttEighth(res["attEighth"].ToString());
                            cni.setAttNinth(res["attNinth"].ToString());
                            cni.setAttTenth(res["attTenth"].ToString());

                            list_cni.Add(cni);
                        }
                    }
                    else
                    {
                        Console.WriteLine("코드 이름 정보가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_cni;
            }
        }
        /* 장비에 따른 장비 이벤트 검색 */
        public List<EquipEventInfo> equip_event_select(string oper_equip_id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<EquipEventInfo> list_eei = new List<EquipEventInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from equip_event_table where equipId = @equipId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", oper_equip_id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            EquipEventInfo eei = new EquipEventInfo();
                            eei.setEquipId(res["equipId"].ToString());
                            eei.setEquipEventId(res["equipEventId"].ToString());
                            eei.setEquipEventType(res["equipEventType"].ToString());
                            eei.setEquipEvemtTime(res["equipEventTime"].ToString());
                            eei.setEquipState(res["equipState"].ToString());
                            eei.setRepairManager(res["repairManager"].ToString());

                            list_eei.Add(eei);
                        }
                    }
                    else
                    {
                        Console.WriteLine("이벤트가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_eei;
            }
        }
        /* 공정에 따른 장비 검색 */
        public List<EquipInfo> equip_select(string oper_id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<EquipInfo> list_ei = new List<EquipInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from equip_table where operId = @operId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@operId", oper_id);

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            EquipInfo ei = new EquipInfo();
                            ei.setEquipId(res["equipId"].ToString());
                            ei.setEquipType(res["equipType"].ToString());
                            ei.setEquipState(Convert.ToInt32(res["equipState"]));
                            ei.setEquipComm(res["equipComm"].ToString());
                            ei.setEquipRecDate(res["equipRecDate"].ToString());
                            ei.setEquipManager(res["equipManager"].ToString());
                            ei.setEquipUpdate(res["equipUpdate"].ToString());

                            list_ei.Add(ei);
                        }
                    }
                    else
                    {
                        Console.WriteLine("장비가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ei;
            }
        }
        /* 장비 추가 */
        public Boolean equip_insert(string equipId, string equipType, string equipIdComm, string equipIdManager, string operId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "insert into equip_table(equipId, equipType, equipComm, equipRecDate, equipManager, operId, equipUpdate) values (@equipId, @equipType, @equipComm, NOW(), @equipManager, @operId, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@equipId", equipId);
                    cmd.Parameters.AddWithValue("@equipType", equipType);
                    cmd.Parameters.AddWithValue("@equipComm", equipIdComm);
                    cmd.Parameters.AddWithValue("@equipManager", equipIdManager);
                    cmd.Parameters.AddWithValue("@operId", operId);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 공정 TYPE 확인*/
        public string oper_type_select(string oper_id)
        {
            string oper_type = null;

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<OperInfo> list_oi = new List<OperInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from oper_table where operId = @operId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@operId", oper_id);
                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            oper_type = res["operType"].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("oper가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return oper_type;
            }

        }
        /* 공정 확인 */
        public List<OperInfo> oper_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<OperInfo> list_oi = new List<OperInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from oper_table order by operSeq";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            OperInfo oi = new OperInfo();
                            oi.setOperId(res["operId"].ToString());
                            oi.setOperType(res["operType"].ToString());
                            oi.setOperCreate(res["operCreate"].ToString());
                            oi.setOperUpdate(res["operUpdate"].ToString());

                            list_oi.Add(oi);
                        }
                    }
                    else
                    {
                        Console.WriteLine("oper가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_oi;
            }

        }
        /* 사용자 삭제 */
        public Boolean user_delete(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "delete from user_table where userId = @userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@userId", id);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 사용자 관리 */
        public List<UserInfo> user_select()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                List<UserInfo> list_ui = new List<UserInfo>();

                try
                {
                    conn.Open();
                    string query = "select * from user_table";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    MySqlDataReader res = cmd.ExecuteReader();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            UserInfo ui = new UserInfo();
                            ui.setUser_id(res["userId"].ToString());
                            ui.setUser_pw("*****");
                            ui.setUser_name(res["userName"].ToString());
                            ui.setUser_pos(res["userPosition"].ToString());
                            ui.setUser_right(res["userRight"].ToString());

                            list_ui.Add(ui);
                        }
                    }
                    else
                    {
                        Console.WriteLine("유저가 존재하지 않습니다.");
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

                return list_ui;
            }

        }
        /* 회원가입 */
        public Boolean sign_up(string userName, string userId, string userPosition, string userRight)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {

                    Console.WriteLine(userName);
                    conn.Open();
                    string query = "insert into user_table values (@userName, @userId, @userPw, @userPosition, @userRight, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@userPw", AES256_PW.EncryptString("1234"));
                    cmd.Parameters.AddWithValue("@userPosition", userPosition);
                    cmd.Parameters.AddWithValue("@userRight", userRight);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 비밀번호 변경 */
        public Boolean password_update(string id, string pw)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "update user_table set userPw = @userPw where userId = @userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@userId", id);
                    cmd.Parameters.AddWithValue("@userPw", pw);

                    int result = cmd.ExecuteNonQuery();

                    if (result != 1) return false;
                    else return true;

                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /* 아이디/비밀번호 로그인 확인 */
        public UserInfo login_check(string userId, string userPw)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                UserInfo ui = null;
                try
                {
                    conn.Open();
                    string query = "select userName, userPw from user_table where userId = @userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@userId", userId);

                    MySqlDataReader res = cmd.ExecuteReader();
                    string name = null;
                    string password = null;
                    ui = new UserInfo();

                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            name = res["userName"].ToString();
                            password = res["userPw"].ToString();
                        }

                        if (userPw.Equals(password))
                        {
                            ui.setUser_name(name);
                            return ui;
                        }
                        else return ui;
                    }
                    else
                    {
                        Console.WriteLine("아이디가 존재하지 않습니다.");
                        return ui;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return ui;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
