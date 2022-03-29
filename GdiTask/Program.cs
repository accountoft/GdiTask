using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using GdiTask.Data;
using GdiTask.Models;

namespace GdiTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            _ = DownloadFileAsync("http://datoteke.durs.gov.si/DURS_zavezanci_PO.zip");

            CreateHostBuilder(args).Build().Run();

            }


        public static async Task DownloadFileAsync(string url)
        {

           var net = new System.Net.WebClient();
          net.DownloadFile(new Uri(url), "durs_zavezanci.zip");

            ExtractFile();
        }

        public static void ExtractFile() {

            try
            {
                string zipPath = @".\durs_zavezanci.zip";
                string extractPath = @".\extractZip";

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch(Exception e)
            {
                Console.WriteLine("Bug %s",e.Message);
            }
            

        }

     
   

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
