HangFire
=========

HangFire provides support for performing **background jobs in ASP.NET applications**. It allows you to define those jobs and process them asynchronously. HangFire helps you to move the long running tasks out of the request processing pipeline, for example:

- Mass newsletter
- Batch import from xml, csv, json
- Creation of archives
- Firing off web hooks
- Deleting users
- Building different graphs
- Image processing
- *etc.*

HangFire stores the information about jobs in the [Redis storage](http://redis.io). So, all this information is retained after restarting the application.

Installation
-------------

HangFire stores its data in the Redis server instance, so you need to install it first. To learn different options and their pros and cons, see the [Installing Redis]() page in the documentation. But for now we'll install it using the simplest method through the NuGet Package Manager Console:

<pre style="background-color: #202020;border: 4px solid silver;border-radius: 3px;color: #E2E2E2;display: block;padding: 10px;">PM> Install-Package Redis-32</pre>

Package Manager will install the Redis binaries to the `<project-folder>\packages\redis-32.<*>\tools` folder. Just open this folder and run the `redis-server.exe` program.

Next, install the HangFire into your **ASP.NET application** using the Package Manager again:

<pre style="background-color: #202020;border: 4px solid silver;border-radius: 3px;color: #E2E2E2;display: block;padding: 10px;">PM> Install-Package HangFire</pre>

Configuration
--------------

During the installation of the HangFire package, the `App_Start\HangFireConfig.cs` file appears in your project. This file contains the instructions to run the HangFire Server during the start-up of your ASP.NET application with the default options. Just build your project and open the following URL in a browser:

<div style="border-radius: 0;border:solid 3px #ccc;background-color:#fcfcfc;box-shadow: 1px 1px 1px #ddd inset, 1px 1px 1px #eee;padding:3px 7px;">
<span style="color: #666;">http://&lt;your-site&gt;</span>/hangfire.axd
</div>

If you see a page like this, then the configuration step is finished. To learn more about configuration or if you do not see that page, the [Configuration page]() in the documentation, especially its Troubleshooting section.

![HangFire Dashboard](https://github.com/odinserj/hangfire/raw/master/Examples/dashboard_min.png)

Usage
------

HangFire consist of the four parts. The **Client** creates background jobs and places them into the **Storage**. The **Server** fetches jobs from the Storage and processes them. The **Monitor** provides the ability to see what's going on with your background jobs.

To make things work, you need to do the following stuff.

### 1. Define a job

Job is a piece of work that will be processed asynchonously. To define it, just create a new class, derive it from the `BackgroundJob` class, override the `Perform` method and provide some properties which will serve as arguments of your job.

```csharp
public void LongRunningJob : BackgroundJob
{
    public string Name { get; set; }

    public override void Perform()
    {
        Console.WriteLine("Hello, {0}!", Name);
    }
}
```

To learn more about job classes, see the [Defining Jobs page]() in the documentation.

### 2. Create a job

You have different options about how to run the defined job. The first and default method is based on job queues. Each queue contains jobs that will be performed in the FIFO order. To enqueue a job, call the following method.

```csharp
Perform.Async<LongRunningJob>(new { Name = "man" });
```

You also can tell HangFire to delay the excecution of the job. After the given delay it will be enqueued to its queue and processed by the server.

```csharp
Perform.In<LongRunningJob>(TimeSpan.FromDays(1), new { Name = "man" });
```

To learn more about different options of the job creation process, see the [corresponding page]() in the documentation.

### 3. Start the processing

If you installed HangFire using the NuGet Package Manager, this step is already completed for you, see the `App_Start\HangFireConfig.cs` class. It contains instructions to run the HangFire Server with default options:

```csharp
var server = new AspNetBackgroundJobServer();
server.Start();
```

You can find more information about the [HangFire Server]() in the documentation.

License
--------

Please see the LICENSE.txt file for licensing details.

Author
-------

Sergey Odinokov, odinserj (at) gmail (dot) com