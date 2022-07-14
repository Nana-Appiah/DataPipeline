using DtPipeline.Bridge;
using System.Diagnostics;
using DtPipeline.Model;

const string Cust_Data_String_Path = @"C:\Users\ofosu\OneDrive\Documents\Projects\DataPipeline\POS_Cust_Data.xlsx";
const string Acct_Data_String_Path = @"C:\Users\ofosu\OneDrive\Documents\Projects\DataPipeline\POS_Acct_Data.xlsx";

//Loading customer data
var customerData = new Data() { 
    filePath = Cust_Data_String_Path
};

var accountData = new Data()
{
    filePath = Acct_Data_String_Path
};

var customerDataList = customerData.getData();

if (customerDataList.Count() > 0)
{
    int cust_success = 0; int cust_failed = 0;
    foreach(var customer in customerDataList)
    {
        var obj = new DtPipeline.DbModel.CustomerDatum() { 
            ChargingPartyId = customer.chargingPartyID,
            SortCode = customer.sortCode,
            AccountNumber = customer.accountNumber,
            TinorGhcard = customer.TINorGhanaCard,
            PhoneNumber = customer.phoneNumber,
            ShortId = customer.shortID,
            UniqueIdName = customer.unique_Id_Name
        };

        if (new CustData() { }.saveCustomerData(obj))
        {
            cust_success += 1;
        }
        else { cust_failed += 1; }
    }

    Console.WriteLine(string.Format("Total records = {0}, Successful inserts = {1}, Failed inserts = {2}", customerDataList.Count().ToString(), cust_success.ToString(), cust_failed.ToString()));
}

var accountDataList = accountData.getData();

if (accountDataList.Count() > 0)
{
    int acc_success = 0; int acc_failed = 0;
    foreach(var acct in accountDataList)
    {
        var obj = new DtPipeline.DbModel.AccountDatum() { 
            ChargingPartyId = acct.chargingPartyID,
            SortCode = acct.sortCode,
            AccountNumber = acct.accountNumber,
            TinorGhcard = acct.TINorGhanaCard,
            PhoneNumber = acct.phoneNumber,
            ShortId = acct.shortID,
            UniqueIdName = acct.unique_Id_Name
        };

        if (new AccountData() { }.saveAccountData(obj)) { acc_success += 1; } else { acc_failed += 1; }

    }

    Console.WriteLine(String.Format("Total records = {0}, Successful inserts = {1}, Failed inserts = {2}",accountDataList.Count().ToString(),acc_success.ToString(),acc_failed.ToString()));
}
