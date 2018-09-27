using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agi = HtmlAgilityPack;
using System.Drawing.Text;

namespace New_Animation_Conversion
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            PrivateFontCollection privateFonts = new PrivateFontCollection();

            privateFonts.AddFontFile("JKG-M_3.ttf");

            Font font = new Font(privateFonts.Families[0], 11f);
            
            //brocas.Font = font;
            result_context.Font = font;

            //queque
            //queque.HeaderStyle = ColumnHeaderStyle.None;

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(@Application.StartupPath + "/Broadcasts.txt", System.Text.Encoding.GetEncoding("utf-16"));
            while ((line = file.ReadLine()) != null)
            {
                brocas.Items.Add(line, false);
                counter++;
            }

            file.Close();

            now_date_text.Text = "현재날짜 : " + DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void under_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Point mousePoint;
        private void move_panner_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void move_panner_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                     this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void brocas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < brocas.Items.Count; ++ix)
                {
                    if (e.Index != ix) brocas.SetItemChecked(ix, false);
                }
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            string clb_string = "";
            for (int x = 0; x <= brocas.CheckedItems.Count - 1; x++)
            {
                clb_string = clb_string + brocas.CheckedItems[x].ToString();
            }
            if (clb_string == "")
            {
                MessageBox.Show("방송사를 선택해주세요.");
                return;
            }
            else
            {
                result_context.Text = "";
                if (url.Text.Contains("/time"))
                {
                    start_conversion_time();
                }
                else
                {
                    start_conversion();
                }
            }
        }
        public void start_conversion_time()
        {
            result_context.Text = "";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString(url.Text);
            

            agi.HtmlDocument doc = new agi.HtmlDocument();
            doc.LoadHtml(html);
            
            agi.HtmlNode id_main = doc.GetElementbyId("main");
            
            //제목 타이틀 추출
            string title = id_main.SelectSingleNode("//h1").InnerText;      //제목
            string re_title = "";
            String result_title;
            //MessageBox.Show(title.Split('年')[0].ToString());
            if (title.Contains("&raquo; "))
            {
                result_title = "";
                if (title.Contains("年"))
                {
                    result_title = title.Split('年')[0].Substring(0, title.Split('年')[0].LastIndexOf(' ')).ToString();
                }
                if (title.Contains("&"))
                {
                    result_title = title.Split('&')[0].ToString().Trim();
                }
                /*for (int r = 0; r < result_title.Length; r++)
                {
                    if (result_title[r] != "&raquo;")
                    {
                        if (r != 0) re_title += " ";
                        //title = result_title[r];
                        re_title += result_title[0];
                    }
                    else
                    {
                        break;
                    }
                }*/
                re_title = result_title;
            }
            else
            {
                re_title = title;
            }
            //re_title==========================================

            //날짜분기추출
            int now_num = 1;
            int data_i = 1;
            String[] now_split = new String[] { };
            var result_date = "";

            //실제날짜 추출
            var ani_date = doc.DocumentNode.SelectSingleNode("//table[@class='section basic']//tr/td[1]").InnerHtml;
            String result_ani_date = ani_date.ToString().Split('月')[0];
            //result_context.Text = ani_date.ToString().Split('月')[0] + "\r\n";

            for (;;)
            {
                result_date = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText;       //날짜 분기
                if (data_i == 3)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                if (data_i == 4)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                if (data_i == 5)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                data_i++;
            }

            String[] now_split2 = now_split[0].Split('-');
            if (Convert.ToInt32(now_split2[1]) == 4) now_num = 2;
            if (Convert.ToInt32(now_split2[1]) == 7) now_num = 3;
            if (Convert.ToInt32(now_split2[1]) == 10) now_num = 4;
            String nowyear = now_split2[0];
            //nowyear+now_num==============================

            //flag_ 추출
            ArrayList flag_ = new ArrayList();
            foreach (var cell in doc.DocumentNode.SelectNodes("//table[@id='ProgList']/tr/td[6]"))
            {
                //MessageBox.Show(cell.InnerText);
                //result_context.Text += cell.InnerText.Replace("！", "").Replace("●", "").Replace("再", "").Replace("Update", "").Replace(" &nbsp;", "").Trim() + "\r\n";
                flag_.Add(" [" + cell.InnerText.Replace("！", "").Replace("●", "").Replace("注", "").Replace("再", "").Replace("Update", "").Replace(" &nbsp;", "").Trim() + "]");
            }
            //flag_============================

            //ch_ 추출 ==============================
            ArrayList ch_ = new ArrayList();
            foreach (var cell in doc.DocumentNode.SelectNodes("//table[@id='ProgList']/tr/td[5]"))
            {
                if (cell.InnerText != "&nbsp;")
                {
                    if (cell.SelectSingleNode(".//div[@class='peNotice']") != null)
                    {
                        if (cell.SelectSingleNode(".//div[@class='peNotice']").InnerText != "")
                            ch_.Add(cell.InnerText.Replace(cell.SelectSingleNode(".//div[@class='peNotice']").InnerText, "").Replace("!", "！").Replace("?", "？"));
                        else
                            ch_.Add(cell.InnerText.Replace("!", "！").Replace("?", "？"));
                    }
                    else if (cell.SelectSingleNode(".//div[@class='peComment']") != null)
                    {
                        if (cell.SelectSingleNode(".//div[@class='peComment']").InnerText != "")
                            ch_.Add(cell.InnerText.Replace(cell.SelectSingleNode(".//div[@class='peComment']").InnerText, "").Replace("!", "！").Replace("?", "？"));
                        else
                            ch_.Add(cell.InnerText.Replace("!", "！").Replace("?", "？"));
                    }
                    else
                    {
                        ch_.Add(cell.InnerText.Replace("!", "！").Replace("?", "？"));
                    }
                }
            }
            //ch_ ========================================

            //날짜==============
            ArrayList day_date = new ArrayList();
            ArrayList time_date = new ArrayList();
            foreach (var cell in doc.DocumentNode.SelectNodes("//table[@id='ProgList']/tr/td[2]"))
            {
                day_date.Add(cell.InnerText.Split('(')[0]);
                time_date.Add(cell.InnerText.Split(')')[1].Replace("&nbsp;", "").Replace(" ", ""));
            }
            //t_date=================


            string clb_string = "";
            for (int x = 0; x <= brocas.CheckedItems.Count - 1; x++)
            {
                clb_string = clb_string + brocas.CheckedItems[x].ToString();
            }

            int cell_num = 0;

            //ArrayList Rs_Array_LIst = new ArrayList();
            Dictionary<int, string> Rs_Array_LIst = new Dictionary<int, string>();
            foreach (var cell in doc.DocumentNode.SelectNodes("//table[@id='ProgList']/tr/td[4]"))
            {
                System.Windows.Forms.Application.DoEvents();
                string numbers = cell.InnerText;
                //MessageBox.Show(time_date[cell_num].ToString());
                string minute_date = "";
                if (time_date[cell_num].ToString().Split(':')[1].Contains('↑'))
                {
                    minute_date = time_date[cell_num].ToString().Split(':')[1].Split('↑')[0];
                }
                else if (time_date[cell_num].ToString().Split(':')[1].Contains('↓'))
                {
                    minute_date = time_date[cell_num].ToString().Split(':')[1].Split('↓')[0];
                }
                else
                {
                    minute_date = time_date[cell_num].ToString().Split(':')[1];
                }
                int hours = 0;
                if (Convert.ToInt32(time_date[cell_num].ToString().Split(':')[0]) < 24)
                {
                    hours = Convert.ToInt32(time_date[cell_num].ToString().Split(':')[0]);
                }
                else
                {
                    hours = Convert.ToInt32(time_date[cell_num].ToString().Split(':')[0]) - 24;
                }

                string flag = "";
                if (flag_[cell_num].ToString() == " []")
                {
                    flag = " ";
                }
                else
                {
                    flag = flag_[cell_num].ToString()+" ";
                }

                //MessageBox.Show(Convert.ToInt32(day_date[cell_num].ToString().Split('-')[0])+" "+ Convert.ToInt32(day_date[cell_num].ToString().Split('-')[1])+" "+ Convert.ToInt32(day_date[cell_num].ToString().Split('-')[2])+" "+ Convert.ToInt32(time_date[cell_num].ToString().Split(':')[0])+" "+ Convert.ToInt32(minute_date));
                DateTime time_1 = new DateTime(Convert.ToInt32(day_date[cell_num].ToString().Split('-')[0]), Convert.ToInt32(day_date[cell_num].ToString().Split('-')[1]), Convert.ToInt32(day_date[cell_num].ToString().Split('-')[2]), hours, Convert.ToInt32(minute_date), 0);

                int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
                int day = Convert.ToInt32(DateTime.Now.ToString("dd"));
                int hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
                int minute = Convert.ToInt32(DateTime.Now.ToString("mm"));
                DateTime time_2 = new DateTime(year, month, day, hour, minute, 0);

                int result = DateTime.Compare(time_1, time_2);

                if (result > 0)
                {
                    cell_num++;
                    continue;
                }

                if (numbers == "")
                {
                    cell_num++;
                    continue;
                }
                if (Convert.ToInt32(numbers) < 10) { numbers = "0" + cell.InnerText; }

                if (result_context.Text.Contains(" - 第" + numbers + "話 " + ch_[cell_num]))
                {
                    cell_num++;
                    continue;
                }
                string ch_str = "〔 " + ch_[cell_num] + " 〕 ";
                if (ch_str == "〔  〕 ") ch_str = "";
                try
                {
                    Rs_Array_LIst.Add(Convert.ToInt32(numbers), "(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + numbers + "話" + flag + "" + ch_str + clb_string + " 1280x720 x264" + "\r\n");
                }
                catch { }
                //result_context.AppendText("(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + numbers + "話 "+ ch_str + clb_string+" 1280x720 x264"+ "\r\n");
                cell_num++;
            }
            //Rs_Array_LIst.Keys.Sort();
            foreach (String re_line in Rs_Array_LIst.Values)
            {
                Application.DoEvents();
                result_context.AppendText(re_line);
            }
        }

        public void start_conversion()
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString(url.Text);
            agi.HtmlDocument doc = new agi.HtmlDocument();
            doc.LoadHtml(html);

            agi.HtmlNode id_main = doc.GetElementbyId("main");

            string title = id_main.SelectSingleNode("//h1").InnerText;      //제목
            string re_title = "";
            String[] result_title;

            if (title.Contains("&raquo; "))
            {
                result_title = title.Split(' ');
                /*for (int r = 0; r < result_title.Length; r++)
                {
                    if (result_title[r] != "&raquo;")
                    {
                        if (r != 0) re_title += " ";
                        //title = result_title[r];
                        re_title += result_title[r];
                    } else
                    {
                        break;
                    }
                }*/
                re_title += result_title[0];
            }
            else
            {
                re_title = title;
            }
            //result_context.Text = title + "\r\n";

            int now_num = 1;
            int data_i = 1;
            String[] now_split = new String[] { };
            var result_date = "";

            //실제날짜 추출
            var ani_date = doc.DocumentNode.SelectSingleNode("//div[@class='tidHeader']//table/tr/td[1]").InnerHtml;
            String result_ani_date = ani_date.ToString().Split('月')[0];
            //result_context.Text = ani_date.ToString().Split('月')[0] + "\r\n";

            for (;;)
            {
                result_date = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText;       //날짜 분기
                if (data_i == 3)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                if (data_i == 4)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                if (data_i == 5)
                {
                    if (result_date.Contains('～'))
                    {
                        now_split = doc.DocumentNode.SelectSingleNode("//table[@class='data']//tr[" + data_i + "]/td[1]").InnerText.Split('～');
                        break;
                    }
                }
                data_i++;
            }

            String[] now_split2 = now_split[0].Split('-');
            if (Convert.ToInt32(now_split2[1]) == 4) now_num = 2;
            if (Convert.ToInt32(now_split2[1]) == 7) now_num = 3;
            if (Convert.ToInt32(now_split2[1]) == 10) now_num = 4;
            String nowyear = now_split2[0];

            
            
            ArrayList ch_ = new ArrayList();

            foreach (var cell in doc.DocumentNode.SelectNodes("//td[@class='ch']"))
            {
                if (cell.InnerText != "&nbsp;")
                {
                    ch_.Add(cell.InnerText);
                }
            }
            ArrayList now_date = new ArrayList();
            int ch_num = 1;
            var team_date = "";
            foreach (var cell in doc.DocumentNode.SelectNodes("//table[@class='schedule']/tbody/tr"))
            {
                foreach (var cell2 in cell.SelectNodes(".//td").Count.ToString())
                {
                    //result_context.Text += Convert.ToInt32(cell2);
                    if (Convert.ToInt32(cell2) == 53)
                    {
                        if (cell.SelectSingleNode(".//td[3]").InnerText != "&nbsp;")
                        {
                            //result_context.Text += doc.DocumentNode.SelectSingleNode("//table[@class='schedule']/tbody/tr[" + ch_num + "]/td[1]").InnerText + "\r\n";
                            team_date = doc.DocumentNode.SelectSingleNode("//table[@class='schedule']/tbody/tr[" + ch_num + "]/td[1]").InnerText.Split(' ')[0];
                            now_date.Add(doc.DocumentNode.SelectSingleNode("//table[@class='schedule']/tbody/tr[" + ch_num + "]/td[1]").InnerText.Split(' ')[0]);
                        }
                    }
                    else if (Convert.ToInt32(cell2) == 52)
                    {
                        if (cell.SelectSingleNode(".//td[2]").InnerText != "&nbsp;")
                        {
                            //result_context.Text += team_date + "\r\n";
                            now_date.Add(team_date);
                        }
                    }
                    else if (Convert.ToInt32(cell2) == 50)
                    {
                        team_date = doc.DocumentNode.SelectSingleNode("//table[@class='schedule']/tbody/tr[" + ch_num + "]/td[1]").InnerText.Split(' ')[0] + "\r\n";
                    }
                    ch_num++;
                }
            }
            ArrayList subtitle_all = new ArrayList();
            ArrayList subtitle_num = new ArrayList();
            ArrayList subtitle_content = new ArrayList();
            ArrayList numsss = new ArrayList();
            int numssd = 0;
            foreach (var cell in doc.DocumentNode.SelectNodes("//td[@class='subtitle']"))
            {
                if (cell.InnerText != "&nbsp;")
                {
                    //MessageBox.Show(cell.InnerText.Substring(0, 1));
                    if (cell.InnerText.Substring(0, 1) == "^")
                    {
                        subtitle_all.Add(cell.InnerText);
                        subtitle_num.Add(cell.InnerText.Split('#')[1].Split(' ')[0]);
                        if (1 < cell.InnerText.Split(' ').Length)
                        {
                            string cells_text = "";
                            for (int c = 1; c < cell.InnerText.Split(' ').Length; c++)
                            {
                                if (c != 1) cells_text += " ";
                                cells_text += cell.InnerText.Split(' ')[c].Replace("!", "！").Replace("?", "？");
                            }
                            subtitle_content.Add(cells_text);
                        }
                        else
                        {
                            subtitle_content.Add(cell.InnerText.Split(' ')[1]);
                        }
                        numsss.Add(numssd);
                        numssd++;
                    }
                    else if (cell.InnerText.Split(' ')[0].Contains("#"))
                    {
                        //result_context.Text += cell.InnerText + "\r\n";
                        subtitle_all.Add(cell.InnerText);
                        subtitle_num.Add(cell.InnerText.Split(' ')[0].Replace("#", ""));
                        if (1 < cell.InnerText.Split(' ').Length)
                        {
                            string cells_text = "";
                            for (int c = 1; c < cell.InnerText.Split(' ').Length; c++)
                            {
                                if (c != 1) cells_text += " ";
                                cells_text += cell.InnerText.Split(' ')[c].Replace("!", "！").Replace("?", "？");
                            }
                            subtitle_content.Add(cells_text);
                        }
                        else
                        {
                            subtitle_content.Add(cell.InnerText.Split(' ')[1]);
                        }
                        numsss.Add(numssd);
                        numssd++;
                    }
                    else
                    {
                        numssd++;
                        continue;
                    }
                }
            }

            

            int notget =0 ;
            ArrayList flag_ = new ArrayList();
            
            foreach (var cell in doc.DocumentNode.SelectNodes("//td[@class='flag nobr']"))
            {
                if ((int)numsss[0] <= (int)notget)
                {
                    //result_context.Text += cell.InnerText.Replace("！", "").Replace("●", "").Replace("再", "").Replace("Update", "").Replace(" &nbsp;", "").Trim() + "\r\n";
                    flag_.Add("[" + cell.InnerText.Replace("！", "").Replace("●", "").Replace("注", "").Replace("再", "").Replace("Update", "").Replace(" &nbsp;", "").Trim() + "] ");
                }
                notget++;
            }

            ArrayList date_sort = new ArrayList();
            ArrayList date_text_sort = new ArrayList();
            int now_info = 0;
            for (int i = 0; i < subtitle_all.Count; i++)
            {
                Application.DoEvents();
                //MessageBox.Show(subtitle_num[i].ToString());
                int nums = Convert.ToInt32(subtitle_num[i]);
                String resert_num = "";

                if (nums < 10)
                {
                    resert_num = "0" + Convert.ToString(subtitle_num[i]);
                }
                else
                {
                    resert_num = Convert.ToString(subtitle_num[i]);
                }

                string clb_string = "";
                for (int x = 0; x <= brocas.CheckedItems.Count - 1; x++)
                {
                    clb_string = clb_string + brocas.CheckedItems[x].ToString();
                }
                String flag = "";
                if (Convert.ToString(flag_[i]) == "[] ")
                    flag = "";
                else
                    flag = Convert.ToString(flag_[i]);

                if (result_context.Text.Contains("第" + resert_num + "話 ") || ch_[i].ToString().Contains(clb_string))
                {
                    continue;
                }
                else
                {
                    if (all_radio.Checked)
                    {    //전체
                        string sub_content = "";
                        if (subtitle_content[i].ToString() != "")
                            sub_content = "〔 " + subtitle_content[i].ToString() + " 〕";
                        result_context.Text += "(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + resert_num + "話 " + flag + sub_content;
                        result_context.Text += clb_string + " 1280x720 x264 \r\n";

                    }
                    else if (now_radio.Checked)
                    { //현재

                        DateTime time_1 = new DateTime(Convert.ToInt32(result_ani_date.Split('年')[0]), Convert.ToInt32(result_ani_date.Split('年')[1]), Convert.ToInt32(now_date[i]), 0, 0, 0);
                        //result_context.Text += now_date_text.Text.Split('-')[0]+ now_date_text.Text.Split('-')[1]+ now_date_text.Text.Split('-')[2];
                        int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                        int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
                        int day = Convert.ToInt32(DateTime.Now.ToString("dd"));
                        DateTime time_2 = new DateTime(year, month, day, 0, 0, 0);
                        if (DateTime.Compare(time_1, time_2) <= 0)
                        {
                            now_info = 1;
                            string sub_content = "";
                            if (subtitle_content[i].ToString() != "")
                                sub_content = "〔 " + subtitle_content[i].ToString() + " 〕";

                            //date_sort.Add(Convert.ToInt32(DateTime.Now.ToString("dd")) - Convert.ToInt32(now_date[i])+ "(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + resert_num + "話 " + flag + sub_content + clb_string + " 1280x720 x264");
                            result_context.Text += "(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + resert_num + "話 " + flag + " " + sub_content;
                            result_context.Text += clb_string + " 1280x720 x264 \r\n";
                        }

                    }

                    else //미래
                    {
                        DateTime time_1 = new DateTime(Convert.ToInt32(result_ani_date.Split('年')[0]), Convert.ToInt32(result_ani_date.Split('年')[1]), Convert.ToInt32(now_date[i]), 0, 0, 0);
                        //result_context.Text += now_date_text.Text.Split('-')[0]+ now_date_text.Text.Split('-')[1]+ now_date_text.Text.Split('-')[2];
                        int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                        int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
                        int day = Convert.ToInt32(DateTime.Now.ToString("dd"));
                        DateTime time_2 = new DateTime(year, month, day, 0, 0, 0);
                        if (DateTime.Compare(time_1, time_2) > 0)
                        {
                            string sub_content = "";
                            if (subtitle_content[i].ToString() != "")
                                sub_content = "〔 " + subtitle_content[i].ToString() + " 〕";
                            result_context.Text += "(" + nowyear + "Q" + now_num + ") " + re_title + " - 第" + resert_num + "話 " + flag + sub_content;
                            result_context.Text += clb_string + " 1280x720 x264 \r\n";
                        }
                    }
                }
            }

            if (now_info == 1)
            {
                string[] tempArray = result_context.Lines;
                result_context.Text = tempArray[result_context.Lines.Length - 2];
                now_info = 0;
            }

            if (result_context.Text == "") MessageBox.Show("추출결과가 없습니다.");
            //result_context.Text += subtitle_.Count;
        }



        // implementation:
        public class ReverseSort : IComparer
        {
            public int Compare(object x, object y)
            {
                // reverse the arguments
                return Comparer.Default.Compare(y, x);
            }

        }

        private void url_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_btn.PerformClick();
            }
        }
        private void input_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IDataObject ido = Clipboard.GetDataObject();
                if (ido.GetDataPresent(typeof(string)))
                {
                    url.Text = (string)ido.GetData(typeof(string));
                }
            }
        }
        
    }
}
