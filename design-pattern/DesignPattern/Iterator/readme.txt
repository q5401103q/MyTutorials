﻿效果及实现要点
1．迭代抽象：访问一个聚合对象的内容而无需暴露它的内部表示。
2．迭代多态：为遍历不同的集合结构提供一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作。
3．迭代器的健壮性考虑：遍历的同时更改迭代器所在的集合结构，会导致问题。

适用性
1．访问一个聚合对象的内容而无需暴露它的内部表示。
2．支持对聚合对象的多种遍历。
3．为遍历不同的聚合结构提供一个统一的接口(即, 支持多态迭代)。

总结
Iterator模式就是分离了集合对象的遍历行为，抽象出一个迭代器类来负责，这样既可以做到不暴露集合的内部结构，又可让外部代码透明的访问集合内部的数据。

摘自http://www.cnblogs.com/Terrylee/archive/2006/09/16/Iterator_Pattern.html