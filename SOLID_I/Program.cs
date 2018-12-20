using System;

// Interface Segregation Principle – If we have an interface which includes too much stuff, then break it apart into smaller interfaces
namespace SOLID_I
{
    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    // ok if you need a multifunction machine
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    // Too much functions for a old fashion printter (Represents the problem)
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            // yep
        }
        //This printer does not need this method
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        //This printer does not need this method
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine("Printed from Printer...");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {
            Console.WriteLine("Scanned from Scanner...");
        }
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            Console.WriteLine("Printed from Photocopier...");
        }

        public void Scan(Document d)
        {
            Console.WriteLine("Scanned from Photocopier...");
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner //
    {

    }

    public struct MultiFunctionMachine : IMultiFunctionDevice
    {
        // compose this out of several modules
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}

