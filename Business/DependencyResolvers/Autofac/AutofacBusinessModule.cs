using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();     // Bu sayede habire new lemek gerekmiyor. Constructorda ver geç. Bizim yerimize instance ın karşılığını verecek nokta burasıdır.
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EFProductImageDal>().As<IProductImageDal>().SingleInstance();
            builder.RegisterType<ProductImageMagager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EFCompanyDal>().As<ICompanyDal>().SingleInstance();
            builder.RegisterType<NewsManager>().As<INewsService>().SingleInstance();
            builder.RegisterType<EFNewsDal>().As<INewsDal>().SingleInstance();
            builder.RegisterType<NewsImageManager>().As<INewsImageService>().SingleInstance();
            builder.RegisterType<EFNewsImageDal>().As<INewsImageDal>().SingleInstance();
            builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
            builder.RegisterType<EFProjectDal>().As<IProjectDal>().SingleInstance();
            builder.RegisterType<ProjectCategoryManager>().As<IProjectCategoryService>().SingleInstance();
            builder.RegisterType<EFProjectCategoryDal>().As<IProjectCategoryDal>().SingleInstance();
            builder.RegisterType<ProjectImageManager>().As<IProjectImageService>().SingleInstance();
            builder.RegisterType<EFProjectImageDal>().As<IProjectImageDal>().SingleInstance();
            builder.RegisterType<WorkManager>().As<IWorkService>().SingleInstance();
            builder.RegisterType<EFWorkDal>().As<IWorkDal>().SingleInstance();
            builder.RegisterType<WorkImageManager>().As<IWorkImageService>().SingleInstance();
            builder.RegisterType<EFWorkImageDal>().As<IWorkImageDal>().SingleInstance();
            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EFMessageDal>().As<IMessageDal>().SingleInstance();





            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
