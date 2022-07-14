using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using DtPipeline.Bridge;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;

using DtPipeline.DbData;
using DtPipeline.DbModel;

namespace DtPipeline.Model
{
    public class Data
    {
        
        public int chargingPartyID { get; set; }
        public int sortCode { get; set; }
        public string accountNumber { get; set; }
        public string TINorGhanaCard { get; set; }
        public string phoneNumber { get; set; }

        public string shortID { get; set; }
        public string unique_Id_Name { get; set; }

        public string filePath { get; set; }

        public List<Data> results = null;

        #region Methods

        public List<Data> getData()
        {
            
            using (var con = Connector.getXLSXConnection(filePath))
            {
                try
                {
                    var cmd = new OleDbCommand()
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from [Data$]",
                        CommandTimeout = 20
                    };

                    
                    using (var d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        { 
                            this.results = new List<Data>();

                            while (d.Read())
                            {
                                Data dt = new Data()
                                {
                                    chargingPartyID = int.Parse(d["CHARGINGPARTYID"].ToString()),
                                    sortCode  = int.Parse(d["SORTCODE"].ToString()),
                                    accountNumber = d["ACCOUNTNUMBER"].ToString(),
                                    TINorGhanaCard = d["TINORGHANACARD"].ToString(),
                                    phoneNumber = d["PHONENUMBER"].ToString(),
                                    shortID = d["SHORT_ID"].ToString(),
                                    unique_Id_Name = d["UNIQUE_ID_NAME"].ToString()
                                };

                                results.Add(dt);
                            }
                        }
                    }

                    return results.ToList();
                }
                catch(Exception x)
                {
                    Debug.Print(x.Message);
                    return results;
                }
            }
        }

        #endregion

    }

    public class AccountData 
        :Data
    {
        private DataPipelineContext config;

        public AccountData()
        {
            config = new DataPipelineContext();
        }

        public int AccountID { get; set; }

        public bool saveAccountData(AccountDatum obj)
        {
            //method saves account data
            bool bln = false;
            try
            {
                using (config)
                {
                    config.AccountData.Add(obj);
                    config.SaveChanges();

                    bln = true;
                }

                return bln;
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                return bln = false;
            }
        }
    }

    public class CustData: Data
    {
        private DataPipelineContext config;

        public CustData()
        {
            config = new DataPipelineContext();
        }
        public int CustomerID { get; set; }

        public bool saveCustomerData(CustomerDatum obj)
        {
            bool bln = false;

            try
            {
                using (config)
                {
                    config.CustomerData.Add(obj);
                    config.SaveChanges();
                    bln = true;
                }

                return bln;
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                return bln;
            }
        }
    }

}
