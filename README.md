﻿用C#实现搜索资源的工具

2016-09-04
一开始应该从简，先把功能实现，不用红黑树。

2016-09-02
准备改写红黑树来适应此项目，改写方法是：
Key是时间，Value是Search的队列，每次DeleteMin就是从时间最小的key删除一个Search，假如Value里面已经没有任何Search,则删除这个Key