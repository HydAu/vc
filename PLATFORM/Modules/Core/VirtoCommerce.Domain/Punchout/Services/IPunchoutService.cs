using System;
using VirtoCommerce.Domain.Punchout.Model;

namespace VirtoCommerce.Domain.Punchout.Services
{
    public interface IPunchoutService
	{
        PunchoutGateway[] GetAllPunchoutGateways();
		void RegisterPunchoutGateway(Func<PunchoutGateway> methodFactory);
	}
}
