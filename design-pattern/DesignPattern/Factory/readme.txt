﻿实现要点:
1.抽象工厂将产品对象的创建延迟到它的具体工厂的子类。
2.如果没有应对“多系列对象创建”的需求变化，则没有必要使用抽象工厂模式，这时候使用简单的静态工厂完全可以。
3.系列对象指的是这些对象之间有相互依赖、或作用的关系，例如游戏开发场景中的“道路”与“房屋”的依赖，“道路”与“地道”的依赖。
4.抽象工厂模式经常和工厂方法模式共同组合来应对“对象创建”的需求变化。
5.通常在运行时刻创建一个具体工厂类的实例，这一具体工厂的创建具有特定实现的产品对象，为创建不同的产品对象，客户应使用不同的具体工厂。
6.把工厂作为单件，一个应用中一般每个产品系列只需一个具体工厂的实例，因此，工厂通常最好实现为一个单件模式。
7.创建产品，抽象工厂仅声明一个创建产品的接口，真正创建产品是由具体产品类创建的，最通常的一个办法是为每一个产品定义一个工厂方法，一个具体的工厂将为每个产品重定义该工厂方法以指定产品，虽然这样的实现很简单，但它确要求每个产品系列都要有一个新的具体工厂子类，即使这些产品系列的差别很小。

优点
1.分离了具体的类。抽象工厂模式帮助你控制一个应用创建的对象的类，因为一个工厂封装创建产品对象的责任和过程。它将客户和类的实现分离，客户通过他们的抽象接口操纵实例，产品的类名也在具体工厂的实现中被分离，它们不出现在客户代码中。
2.它使得易于交换产品系列。一个具体工厂类在一个应用中仅出现一次——即在它初始化的时候。这使得改变一个应用的具体工厂变得很容易。它只需改变具体的工厂即可使用不同的产品配置，这是因为一个抽象工厂创建了一个完整的产品系列，所以整个产品系列会立刻改变。
3.它有利于产品的一致性。当一个系列的产品对象被设计成一起工作时，一个应用一次只能使用同一个系列中的对象，这一点很重要，而抽象工厂很容易实现这一点。

缺点
1.难以支持新种类的产品。难以扩展抽象工厂以生产新种类的产品。这是因为抽象工厂几口确定了可以被创建的产品集合，支持新种类的产品就需要扩展该工厂接口，这将涉及抽象工厂类及其所有子类的改变。

适用性
在以下情况下应当考虑使用抽象工厂模式：
1.一个系统不应当依赖于产品类实例如何被创建、组合和表达的细节，这对于所有形态的工厂模式都是重要的。
2.这个系统有多于一个的产品族，而系统只消费其中某一产品族。
3.同属于同一个产品族的产品是在一起使用的，这一约束必须在系统的设计中体现出来。
4.系统提供一个产品类的库，所有的产品以同样的接口出现，从而使客户端不依赖于实现。

摘自http://www.cnblogs.com/Terrylee/archive/2005/12/13/295965.html