using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        //Dictionary to store user id and summary
        static Dictionary<int, List<String>> userDict = new Dictionary<int, List<String>>();

        /// <summary>
        /// Method to add user id and summary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rides"></param>
        /// <param name="type"></param>
        public void AddUserToDIctionary(int id, Ride[] rides, GenerateCabInvoice.RideType type)
        {
            int flag = 0;
            List<string> summaryList = new List<string>();
            string rideType = string.Empty;
            GenerateCabInvoice cabInvoice = new GenerateCabInvoice(type);
            //Check the type of ride
            if(type.Equals(GenerateCabInvoice.RideType.NORMAL))
            {
                rideType = "Normal";
            }
            else
            {
                rideType = "Premium";
            }
            //Appending summary to string
            string summary = $"{rideType}\n{cabInvoice.GetInvoiceSummary(rides)}";

            //check whether the userid is already exists in dictionary or not
            foreach (KeyValuePair<int, List<String>> dict in userDict)
            {
                if(dict.Key == id)
                {
                    //if exixts append new summary to list
                    List<string> list = userDict[dict.Key];
                    list.Add(summary);
                    flag = 1;
                    break;
                }
                
            }
            //if not exixts add it to dictionary
            if (flag == 0)
            {
                summaryList.Add(summary);
                userDict.Add(id, summaryList);
            }

        }
        //Method to print values in dictionary
        public void printDict()
        {
            foreach(KeyValuePair<int, List<String>> dict in userDict)
            {
                Console.WriteLine($"User ID:- {dict.Key}\n");
                foreach(var i in dict.Value)
                {
                    Console.WriteLine($"{i}\n");
                }
            }
        }
        /// <summary>
        /// Method to serach user summary form dictionary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SearchUser(int id)
        {
            string res = $"User Id :-{id}\n";
            
            foreach (KeyValuePair<int, List<String>> dict in userDict)
            {
                if (dict.Key == id)
                {
                    List<string> list = userDict[dict.Key];
                    foreach(var i in list)
                    {
                        res += i+"\n*****************\n";
                    }
                    
                    return res;
                }

            }
            return $"User Id :-{id} not found";
        }
    }
}
