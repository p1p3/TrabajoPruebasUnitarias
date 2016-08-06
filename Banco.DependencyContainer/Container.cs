using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Services;
using Banco.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace Banco.DependencyContainer
{
    public static class Container
    {
        public static void RegisterDependencies()
        {

            DependeciesContainer.RegisterType<INotificaciones, Notificaciones>();
            DependeciesContainer.RegisterType<ITransferencias, Transferencias>();
        }

        public static ITransferencias GetTransferenciasServices()
        {
            return DependeciesContainer.Resolve<ITransferencias>();
        }

        public static IUnityContainer DependeciesContainer { get; set; } = new UnityContainer();
    }
}
