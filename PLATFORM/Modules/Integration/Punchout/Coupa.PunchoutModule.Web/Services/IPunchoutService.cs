using Coupa.PunchoutModule.Web.Model;
using System;

namespace Coupa.PunchoutModule.Web.Services
{
    public interface IPunchoutService
	{
        PunchoutGateway[] GetAllPunchoutGateways();
		void RegisterPunchoutGateway(Func<PunchoutGateway> methodFactory);
	}
}
