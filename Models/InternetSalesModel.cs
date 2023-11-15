using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace sqlChartsDemo.Models
{
    public class InternetSalesModel
    {
        public JArray Data { set; get; }
        public string Name = "Internet Sales By Store - Daily";
        public string ReportName = "1006D";


        static public (Dictionary<string, List<int>>, List<string>) FormatData(JArray data)

        {
            

            Dictionary<string, List<int>> valueDictionary = new Dictionary<string, List<int>>();

            List<string> AllProps = data[0].ToObject<JObject>().Properties().Select(prop => prop.Name).ToList();
            Console.WriteLine("PROPS COUNT: " + AllProps.Count);


            List<string> NamesList = new List<string>();



            for (var field = 2; field < AllProps.Count() - 2; field++)



            {

                string fieldName = AllProps[field];

                string fieldLabel = data[0][fieldName].ToString();

                Console.WriteLine("field Label " + fieldLabel.ToString());
          



                List<int> valueList = new List<int>();



                for (var modelObjIndex = 1; modelObjIndex < data.Count - 1; modelObjIndex++)

                {


              


                    try
                    {

                        JObject? currentObject = data[modelObjIndex].ToObject<JObject>();

                        string objName = currentObject["FIELD2"].ToString();
                        

                        string? fieldValue = currentObject[fieldName].ToString().Replace("$", "").Replace(",", "");
                     
                 


                        if (fieldValue.Substring(0, 1) == "(") { var newFieldValue = fieldValue.Substring(1, fieldValue.Length - 2); fieldValue = "-" + newFieldValue; Console.WriteLine("fieldValue" + fieldValue); }




                        if (Int64.TryParse(fieldValue, out long result))
                        {
                            valueList.Add((int)result);
                        }

                        if (NamesList.Contains(objName) == false) NamesList.Add(objName); 


                    }


                    catch (Exception er)
                    {
                        Console.WriteLine("err" + er);
                    }

                }

    

                valueDictionary.Add(fieldLabel, valueList);
          
         
            }

            foreach (KeyValuePair<string, List<int>> kvp in valueDictionary)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            return (valueDictionary,NamesList);
        }
    }
}

