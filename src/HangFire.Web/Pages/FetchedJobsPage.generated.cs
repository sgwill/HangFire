﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\FetchedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\FetchedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\FetchedJobsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Pages\FetchedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Pages\FetchedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\FetchedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Pages\FetchedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class FetchedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");










            
            #line 10 "..\..\Pages\FetchedJobsPage.cshtml"
  
    Layout = new LayoutPage
        {
            Title = Queue.ToUpperInvariant(),
            Subtitle = "Fetched jobs",
            Breadcrumbs = new Dictionary<string, string>
                {
                    { "Queues", Request.LinkTo("/queues") },
                    { Queue.ToUpperInvariant(), Request.LinkTo("/queues/" + Queue) }
                },
            BreadcrumbsTitle = "Fetched jobs",
        };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<FetchedJobDto> fetchedJobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.FetchedCount(Queue))
        {
            BasePageUrl = Request.LinkTo("/queues/fetched/" + Queue)
        };

        fetchedJobs = monitor
            .FetchedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 43 "..\..\Pages\FetchedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        The queue is empty.\r\n    </div>\r\n");


            
            #line 48 "..\..\Pages\FetchedJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 54 "..\..\Pages\FetchedJobsPage.cshtml"
                         Write(Request.LinkTo("/enqueued/requeue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Enqueueing..."">
                <span class=""glyphicon glyphicon-repeat""></span>
                Requeue jobs
            </button>

            <button class=""js-jobs-list-command btn btn-sm btn-default""
                    data-url=""");


            
            #line 61 "..\..\Pages\FetchedJobsPage.cshtml"
                         Write(Request.LinkTo("/enqueued/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 68 "..\..\Pages\FetchedJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th class=""min-width"">State</th>
                    <th>Job</th>
                    <th class=""align-right"">Fetched</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 84 "..\..\Pages\FetchedJobsPage.cshtml"
                 foreach (var job in fetchedJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row hover\">\r\n                        " +
"<td>\r\n                            <input type=\"checkbox\" class=\"js-jobs-list-che" +
"ckbox\" name=\"jobs[]\" value=\"");


            
            #line 88 "..\..\Pages\FetchedJobsPage.cshtml"
                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                        </td>\r\n                        <td class=\"min-width" +
"\">\r\n                            <a href=\"");


            
            #line 91 "..\..\Pages\FetchedJobsPage.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 91 "..\..\Pages\FetchedJobsPage.cshtml"
                                                                    Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </td>\r\n                        <td class=\"min-width" +
"\">\r\n                            <span class=\"label label-default\" style=\"");


            
            #line 94 "..\..\Pages\FetchedJobsPage.cshtml"
                                                                 Write(JobHistoryRenderer.ForegroundStateColors.ContainsKey(job.Value.State) ? String.Format("background-color: {0};", JobHistoryRenderer.ForegroundStateColors[job.Value.State]) : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 95 "..\..\Pages\FetchedJobsPage.cshtml"
                           Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                        </td>\r\n           " +
"             <td>\r\n                            <a class=\"job-method\" href=\"");


            
            #line 99 "..\..\Pages\FetchedJobsPage.cshtml"
                                                   Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 100 "..\..\Pages\FetchedJobsPage.cshtml"
                           Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n                        </td>\r\n              " +
"          <td class=\"align-right\">\r\n");


            
            #line 104 "..\..\Pages\FetchedJobsPage.cshtml"
                             if (job.Value.FetchedAt.HasValue)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span data-moment=\"");


            
            #line 106 "..\..\Pages\FetchedJobsPage.cshtml"
                                              Write(JobHelper.ToStringTimestamp(job.Value.FetchedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 107 "..\..\Pages\FetchedJobsPage.cshtml"
                               Write(job.Value.FetchedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");


            
            #line 109 "..\..\Pages\FetchedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");


            
            #line 112 "..\..\Pages\FetchedJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 116 "..\..\Pages\FetchedJobsPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 116 "..\..\Pages\FetchedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 116 "..\..\Pages\FetchedJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
