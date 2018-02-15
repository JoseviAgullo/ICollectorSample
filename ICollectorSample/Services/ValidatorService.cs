using System;
using System.Threading;

namespace ICollectorSample.Services
{
    public class ValidatorService
    {
	    public bool ValidateElement(string itemToValidate)
	    {
		    Thread.Sleep(TimeSpan.FromSeconds(0.1));

		    return true;
	    }
    }
}
