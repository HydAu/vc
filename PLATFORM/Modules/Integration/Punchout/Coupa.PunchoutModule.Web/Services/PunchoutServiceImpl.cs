using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupa.PunchoutModule.Web.Services
{
    public class PunchoutServiceImpl : IPunchoutService
	{
		private List<Func<Model.PunchoutGateway>> _punchoutGateways = new List<Func<Model.PunchoutGateway>>();
		
		#region IPunchoutService Members

		public Model.PunchoutGateway[] GetAllPunchoutGateways()
		{
			return _punchoutGateways.Select(x => x()).ToArray();
		}

		public void RegisterPunchoutGateway(Func<Model.PunchoutGateway> methodFactory)
		{
			if (methodFactory == null)
			{
				throw new ArgumentNullException("methodFactory");
			}

            _punchoutGateways.Add(methodFactory);
		}

		#endregion
	}
}
