// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;


namespace ConsoleApp1;

internal class Program
{

    private static readonly string baseId = "appANQzeTwRF05Qf6";
    private static readonly string appKey = "keyVuV9M6kkQHnMU2";

    private static async Task Main(string[] args)

    {

         

        using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
        {
            Task<AirtableRetrieveRecordResponse> task =
                airtableBase.RetrieveRecord("Job Applications", "reckoKAjTyppOLMxQ");
            var response = await task;
            if (!response.Success)
            {
                string errorMessage = null;
                if (response.AirtableApiError is AirtableApiException)
                {
                    errorMessage = response.AirtableApiError.ErrorMessage;
                }
                else
                {
                    errorMessage = "Unknown error";
                }
                // Report errorMessage
            }
            else
            {
                var record = response.Record;
                // Do something with your retrieved record.
                // Such as getting the attachmentList of the record if you
                // know the Attachment field name
                var recordName = response.Record.GetField("Name");
                var companyName = response.Record.GetField("Company");
                var jobTitle = response.Record.GetField("Job Position");
                var status = response.Record.GetField("Status");
                var dateApplied = response.Record.GetField("Created");
                var url = response.Record.GetField("URL");


                Console.WriteLine("Name: " + recordName);
                Console.WriteLine("Company: " + companyName);
                Console.WriteLine("Job Title: " + jobTitle);
                Console.WriteLine("Status: " + status);
                Console.WriteLine("Date Applied: " + dateApplied);
                Console.WriteLine("URL: " + url);
            }
        }
    }
}
    

   
