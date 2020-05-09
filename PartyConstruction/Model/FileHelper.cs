using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PartyConstruction.Models
{
    public static class FileHelper
    {

        /*废弃的方法     
        /// <summary>
        /// 保存投票账号列表到文件
        /// </summary>
        public static void SaveIDList(List<string> list )
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(HttpRuntime.AppDomainAppPath + "\\Lib\\" + "DataC.txt"))
                {
                    foreach (string s in list)
                    {
                        sw.WriteLine(s);

                    }
                }
            }
            catch (Exception e)
            {

                WriteLog(e);
            }
        }



        public static void SaveHtml()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(HttpRuntime.AppDomainAppPath + "Html.txt"))
                {
                    int index = 1;
                    foreach (var cand in AppDomain.Candidates)
                    {
                        sw.WriteLine("<fieldset data-role = \"controlgroup\" data-type = \"horizontal\" id = \"{0}\" >", cand.Name);
                        sw.WriteLine("<legend > {0} </legend >", cand.Name);
                        sw.WriteLine("<label for= \"{0}A\" > 优秀 </label >", cand.Name);
                        sw.WriteLine("<input type = \"radio\" name = \"{0}\" id = \"{0}A\" value = \"10\" >", cand.Name);
                        sw.WriteLine("<label for= \"{0}B\" > 称职 </label >", cand.Name);
                        sw.WriteLine("<input type = \"radio\" name = \"{0}\" id = \"{0}B\" value = \"8\" checked>", cand.Name);
                        sw.WriteLine("<label for= \"{0}C\" > 基本称职 </label >     ", cand.Name);
                        sw.WriteLine("<input type = \"radio\" name = \"{0}\" id = \"{0}C\" value = \"7\" >", cand.Name);
                        sw.WriteLine("<label for= \"{0}D\" > 不称职 </label >", cand.Name);
                        sw.WriteLine("<input type = \"radio\" name = \"{0}\" id = \"{0}D\" value = \"5\" >", cand.Name);
                        sw.WriteLine("</fieldset >", cand.Name);

                        index++;
                    }
                }
            }
            catch (Exception e)
            {

                WriteLog(e);
            }

        }
        */

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="e"></param>
        public static void WriteLog(Exception e)
        {
            using (StreamWriter sw = new StreamWriter(HttpRuntime.AppDomainAppPath + "Log.txt", true))
            {
                sw.WriteLine(DateTime.Now);
                if (e.InnerException != null)
                {
                    sw.WriteLine(e.InnerException.Message);
                }
                else
                {
                    sw.WriteLine(e.Message);
                }
            }
        }
    }
}