﻿using Rocket.API.Commands;
using Rocket.API.Configuration;
using Rocket.API.DependencyInjection;
using Rocket.API.Eventing;
using Rocket.API.I18N;
using Rocket.API.Permissions;
using Rocket.API.Plugin;
using Rocket.Core.Commands;
using Rocket.Core.Configuration.Json;
using Rocket.Core.Configuration.Xml;
using Rocket.Core.Eventing;
using Rocket.Core.I18N;
using Rocket.Core.Permissions;
using Rocket.Core.Plugins;

namespace Rocket.Core.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            //singleton dependencies
            container.RegisterSingletonType<IEventManager, EventManager>();
            container.RegisterSingletonType<ICommandHandler, DefaultCommandHandler>("default_cmdhandler", null);
            container.RegisterSingletonType<ICommandHandler, CommandHandlerProxy>("proxy_cmdhandler", null);
            container.RegisterSingletonType<IPluginManager, PluginManager>();
            container.RegisterSingletonType<ICommandProvider, PluginManager>();

            container.RegisterSingletonType<IPermissionProvider, ConfigurationPermissionProvider>("config_permissions");
            container.RegisterSingletonType<IPermissionProvider, ConsolePermissionProvider>("console_permissions");
            container.RegisterSingletonType<IPermissionProvider, PermissionProviderProxy>("proxy_permissions", null);

            //transient dependencies
            container.RegisterType<ITranslationLocator, TranslationLocator>();

            container.RegisterType<IConfiguration, JsonConfiguration>();
            container.RegisterType<IConfiguration, JsonConfiguration>("json");
            container.RegisterType<IConfiguration, XmlConfiguration>("xml");
        }
    }
}