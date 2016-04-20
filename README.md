# Design Patterns Reloaded
The idea of this implementation comes from a very interesting [talk by Remi Forax](https://github.com/forax/design-pattern-reloaded/) which he has given [at ParisJUG in June 2015](http://www.parisjug.org/xwiki/wiki/oldversion/view/Meeting/20150602) and [at Devoxx in November 2015](http://cfp.devoxx.be/2015/talk/KSD-8798/Design_Pattern_Reloaded).
See also the corresponding [slides](https://speakerdeck.com/forax/design-pattern-reloaded-parisjug) or the complete [Devoxx session on YouTube](https://www.youtube.com/watch?v=-k2X7guaArU).

I couldn't resist to work with the examples myself. But because there is already [the original implementation in Java 8](https://github.com/forax/design-pattern-reloaded/) and a port in [Scala](https://github.com/YannMoisan/design-pattern-reloaded) I started another experiment to port all the examples to .NET (C#). 
Although I have ported almost all the examples, not all of them are equally reasonable and elegant in .NET as the original Java versions.
Reasons for this are different language features between .NET and Java as for example:

* Java uses [functional interfaces](http://docs.oracle.com/javase/8/docs/api/java/lang/FunctionalInterface.html) whereas .NET uses [delegates](https://msdn.microsoft.com/en-us/library/ms173171.aspx)
* Interfaces in Java can have [default methods](http://docs.oracle.com/javase/tutorial/java/IandI/defaultmethods.html) which are not possible in .NET
* Interfaces in Java can have [static methods](http://www.journaldev.com/2752/java-8-interface-changes-static-methods-default-methods-functional-interfaces) which are not possible in .NET
* On the other hand .NET supports [extension methods](https://msdn.microsoft.com/en-us/library/bb383977.aspx) which are not available in Java
* Java 8 introduces the [Stream API](http://www.journaldev.com/2774/java-8-stream-api-example-tutorial) whereas .NET supports [LINQ (Language-Integrated Query)](https://msdn.microsoft.com/en-us/library/bb397926.aspx)
* Java uses [type erasure](http://docs.oracle.com/javase/tutorial/java/generics/erasure.html) whereas .NET doesn't
