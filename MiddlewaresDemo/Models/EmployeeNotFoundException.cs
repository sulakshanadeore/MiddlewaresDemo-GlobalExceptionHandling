namespace MiddlewaresDemo.Models
{

	[Serializable]
	public class EmployeeNotFoundExceptionException : Exception
	{
		public EmployeeNotFoundExceptionException() { }
		public EmployeeNotFoundExceptionException(string message) : base(message) { }
		public EmployeeNotFoundExceptionException(string message, Exception inner) : base(message, inner) { }
		protected EmployeeNotFoundExceptionException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
