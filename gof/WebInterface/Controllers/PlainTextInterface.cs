using System;
using System.Collections.Generic;
using WebInterface.Interfaces;

namespace WebInterface.Controllers
{
    // TODO: Implementation
    internal class PlainTextInterface : Interface
    {
        private string binaryOperationStream;

        public PlainTextInterface(string binaryOperationStream)
        {
            this.binaryOperationStream = binaryOperationStream;
        }

        public BinaryOperation Operation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<double> Parse()
        {
            throw new NotImplementedException();
        }
    }
}