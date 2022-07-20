namespace Ac.Infra.Service
{
    public static class LoggingEvents
    {
        // Controller - DataCentreControllerEvents
        public static readonly EventId eidInfoDataCentreControllerGet = new EventId(101, "InfoDataCentreControllerGet");
        public static readonly EventId eidInfoDataCentreControllerGetById = new EventId(102, "InfoDataCentreControllerGetById");

        public static readonly EventId eidWarningDataCentreControllerGetNotFound = new EventId(1011, "WarningDataCentreControllerGetNotFound");

        public static readonly EventId eidWarningDataCentreControllerGetByIdBadRequest = new EventId(1021, "WarningDataCentreControllerGetByIdBadRequest");
        public static readonly EventId eidWarningDataCentreControllerGetByIdNotFound = new EventId(1022, "WarningDataCentreControllerGetByIdNotFound");

        // Business - DataCentreFactoryEvents
        public static readonly EventId eidArgExCreateDataCentreName = new EventId(1001, "ArgExCreateDataCentreName");
        public static readonly EventId eidArgExCreateDataCentreLocation = new EventId(1002, "ArgExCreateDataCentreLocation");

        public static readonly EventId eidArgExGetDataCentres = new EventId(1500, "ArgExGetDataCentres");

        // Service - DataCentreServiceEvents
        public static readonly EventId eidInfoDataCentreServiceGet = new EventId(10001, "InfoDataCentreServiceGet");
        public static readonly EventId eidInfoDataCentreServiceGetById = new EventId(10002, "InfoDataCentreServiceGetById");






        // Controller - ServerControllerEvents
        public static readonly EventId eidInfoServerControllerGet = new EventId(201, "InfoServerControllerGet");
        public static readonly EventId eidInfoServerControllerGetById = new EventId(202, "InfoServerControllerGetById");

        public static readonly EventId eidWarningServerControllerGetNotFound = new EventId(2011, "WarningServerControllerGetNotFound");

        public static readonly EventId eidWarningServerControllerGetByIdBadRequest = new EventId(2021, "WarningServerControllerGetByIdBadRequest");
        public static readonly EventId eidWarningServerControllerGetByIdNotFound = new EventId(2022, "WarningServerControllerGetByIdNotFound");

        // Business - ServerFactoryEvents
        public static readonly EventId eidArgExCreateServerName = new EventId(2001, "ArgExCreateServerName");
        public static readonly EventId eidArgExCreateServerDomain = new EventId(2002, "ArgExCreateServerDomain");
        public static readonly EventId eidArgExCreateServerIpAddress = new EventId(2003, "ArgExCreateServerIpAddress");
        public static readonly EventId eidArgExCreateServerDescription = new EventId(2004, "ArgExCreateServerDescription");

        public static readonly EventId eidArgExCreateServerVirtualServerPhysicalHostName = new EventId(2005, "ArgExCreateServerVirtualServerPhysicalHostName");

        public static readonly EventId eidArgExCreateServerPhysicalManagementIp = new EventId(2006, "ArgExCreateServerPhysicalManagementIp");
        public static readonly EventId eidArgExCreateServerPhysicalMake = new EventId(2007, "ArgExCreateServerPhysicalMake");
        public static readonly EventId eidArgExCreateServerPhysicalModel = new EventId(2008, "ArgExCreateServerPhysicalModel");

        public static readonly EventId eidArgExGetServers = new EventId(2500, "ArgExGetServers");

        // Service - ServerServiceEvents
        public static readonly EventId eidInfoServerServiceGet = new EventId(20001, "InfoServerServiceGet");
        public static readonly EventId eidInfoServerServiceGetById = new EventId(20002, "InfoServerServiceGetById");

    }
}