using SchoolRegister.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SchoolRegister.Web.Components
{
    public class SchoolRegisterSession
    {
        private static ChannelFactory<ISchoolRegisterService> _schoolRegisterChannelFactory;
		private ISchoolRegisterService _schoolRegisterService;

		private static ChannelFactory<ISchoolRegisterService> CodeServiceChannelFactory
		{
			get
			{
				if (_schoolRegisterChannelFactory == null)
                    _schoolRegisterChannelFactory = new ChannelFactory<ISchoolRegisterService>("SchoolRegisterServiceEndpoint");

				return _schoolRegisterChannelFactory;
			}
		}

		public ISchoolRegisterService SchoolRegisterService
		{
			get
			{
				if (_schoolRegisterService == null)
					_schoolRegisterService = CodeServiceChannelFactory.CreateChannel();

				return _schoolRegisterService;
			}
		}

		public static SchoolRegisterSession Current
		{
			get
			{
                if (HttpContext.Current.Session["SchoolRegisterSession"] == null)
                    HttpContext.Current.Session["SchoolRegisterSession"] = new SchoolRegisterSession();
                return (SchoolRegisterSession)HttpContext.Current.Session["SchoolRegisterSession"];
			}
		}

		private SchoolRegisterSession()
		{
		}
    }
}