using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SertifikalariListele_CAP
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Store store = new X509Store(StoreName.My);
            X509Store storeCurrentUser = new X509Store(StoreLocation.CurrentUser);          
            X509Store storeLocalMachine = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("STORE CERTIFICATES");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 cert in store.Certificates) {
                Console.WriteLine(string.Format("{0} / {1} ", cert.SubjectName.Name, cert.IssuerName.Name));
            }
            store.Close();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("CURRENT USER CERTIFICATES");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");           
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 cert in storeCurrentUser.Certificates)
            {
                Console.WriteLine(string.Format("{0} / {1} ", cert.SubjectName.Name, cert.IssuerName.Name));
            }
            storeCurrentUser.Close();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("LOCAL MACHINE CERTIFICATES");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");           
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 cert in storeLocalMachine.Certificates)
            {
                Console.WriteLine(string.Format("{0} / {1} ", cert.SubjectName.Name, cert.IssuerName.Name));
            }
            storeLocalMachine.Close();

            Console.Read();
        }
    }
}
