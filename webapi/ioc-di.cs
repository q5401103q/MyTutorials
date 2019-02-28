public class MvcApplication : System.Web.HttpApplication
{
	protected void Application_Start()
	{
		AreaRegistration.RegisterAllAreas();
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		RouteConfig.RegisterRoutes(RouteTable.Routes);
		BundleConfig.RegisterBundles(BundleTable.Bundles);

		//获取程序集信息
		Assembly controllerAssembly = Assembly.GetExecutingAssembly();
		
		//初始化构造器
		var builder = new ContainerBuilder();
		//注册程序集
		builder.RegisterControllers(controllerAssembly);
		//注入Repository
		builder.RegisterAssemblyTypes(controllerAssembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
		//初始化容器
		var container = builder.Build();
		//将MVC的控制器对象实例交由autofac来创建
		DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
	}
}