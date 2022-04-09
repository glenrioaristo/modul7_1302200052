﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul7_1302200052
{
    internal class program
    {
        static void Main(string[] args)
        {
            BankTransferConfig bankConfig = new BankTransferConfig();
            dynamic conf = GetConf(bankConfig);

            if (conf.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            string uangDiTranferStr = Console.ReadLine();
            int uangDiTransfer = int.Parse(uangDiTranferStr);
            int biayaTransfer;

            if (uangDiTransfer <= (int)conf.transfer.threshold)
            {
                biayaTransfer = conf.transfer.low_fee;
            }
            else
            {
                biayaTransfer = conf.transfer.high_fee;
            }

            if (conf.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + biayaTransfer);
                Console.WriteLine("Total amount = " + (biayaTransfer + uangDiTransfer) + "\n");
                Console.WriteLine("Select transfer method");
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Biaya transfer = " + biayaTransfer);
                Console.WriteLine("Total biaya = " + (biayaTransfer + uangDiTransfer) + "\n");
                Console.WriteLine("Pilih metode transfer");
            }

            int index = 0;
            foreach (var mthd in conf.methods)
            {
                index++;
                Console.WriteLine(index + ". " + mthd);
            }

            Console.WriteLine();
           
            if (conf.lang == "en")
            {
                Console.WriteLine("Please type '" + conf.confirmation.en + "' to confirm the transaction:");

                string confirm = Console.ReadLine();

                if (confirm == (string)conf.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Ketik '" + conf.confirmation.id + "' untuk mengkonfirmasi transaksi:");

                string confirm = Console.ReadLine();

                if (confirm == (string)conf.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }

        private static dynamic GetConf(BankTransferConfig bankConfig)
        {
            return bankConfig.ReadJson();
        }
    }
}