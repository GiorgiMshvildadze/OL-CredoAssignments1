﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringForSRP
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        public Invoice GenerateInvoice(Book book)
        {
            return new Invoice();
        }
    }
}
