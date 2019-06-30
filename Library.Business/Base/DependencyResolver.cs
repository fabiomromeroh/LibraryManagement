
using System.ComponentModel.Composition;
using Core.DI;
using Library.Business;
using Library.Data;
using Library.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Business.Base
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : Core.DI.IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {

            registerComponent.RegisterType<IBorrowLogic, BorrowLogic>();
            registerComponent.RegisterType<IBorrowRepository, BorrowRepository>();

            registerComponent.RegisterType<IBookLogic, BookLogic>();
            registerComponent.RegisterType<IBookRepository, BookRepository>();
        }
    }
}
