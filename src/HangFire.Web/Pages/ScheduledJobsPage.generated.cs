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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Pages\ScheduledJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\ScheduledJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\ScheduledJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\ScheduledJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class ScheduledJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");







            
            #line 7 "..\..\Pages\ScheduledJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Scheduled Jobs" };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<ScheduledJobDto> scheduledJobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.ScheduledCount())
        {
            BasePageUrl = Request.LinkTo("/scheduled")
        };

        scheduledJobs = monitor.ScheduledJobs(pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 29 "..\..\Pages\ScheduledJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        There are no scheduled jobs.\r\n    </d" +
"iv>\r\n");


            
            #line 34 "..\..\Pages\ScheduledJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 40 "..\..\Pages\ScheduledJobsPage.cshtml"
                         Write(Request.LinkTo("/scheduled/enqueue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Enqueueing..."">
                <span class=""glyphicon glyphicon-play""></span>
                Enqueue now
            </button>

            <button class=""js-jobs-list-command btn btn-sm btn-default""
                    data-url=""");


            
            #line 47 "..\..\Pages\ScheduledJobsPage.cshtml"
                         Write(Request.LinkTo("/scheduled/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 54 "..\..\Pages\ScheduledJobsPage.cshtml"
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
                    <th>Enqueue</th>
                    <th>Job</th>
                    <th class=""align-right"">Scheduled</th>
                </tr>
            </thead>
");


            
            #line 69 "..\..\Pages\ScheduledJobsPage.cshtml"
             foreach (var job in scheduledJobs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr class=\"js-jobs-list-row ");


            
            #line 71 "..\..\Pages\ScheduledJobsPage.cshtml"
                                        Write(!job.Value.InScheduledState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 71 "..\..\Pages\ScheduledJobsPage.cshtml"
                                                                                                Write(job.Value.InScheduledState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <td>\r\n");


            
            #line 73 "..\..\Pages\ScheduledJobsPage.cshtml"
                         if (job.Value.InScheduledState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input type=\"checkbox\" class=\"js-jobs-list-checkbox\" " +
"name=\"jobs[]\" value=\"");


            
            #line 75 "..\..\Pages\ScheduledJobsPage.cshtml"
                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 76 "..\..\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"min-width\">\r\n          " +
"              <a href=\"");


            
            #line 79 "..\..\Pages\ScheduledJobsPage.cshtml"
                            Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 80 "..\..\Pages\ScheduledJobsPage.cshtml"
                       Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");


            
            #line 82 "..\..\Pages\ScheduledJobsPage.cshtml"
                         if (!job.Value.InScheduledState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span title=\"Job\'s state has been changed while fetch" +
"ing data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 85 "..\..\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"min-width\">\r\n          " +
"              <span data-moment=\"");


            
            #line 88 "..\..\Pages\ScheduledJobsPage.cshtml"
                                      Write(JobHelper.ToStringTimestamp(job.Value.EnqueueAt));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 89 "..\..\Pages\ScheduledJobsPage.cshtml"
                       Write(job.Value.EnqueueAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </span>\r\n                    </td>\r\n                   " +
" <td>\r\n                        <a class=\"job-method\" href=\"");


            
            #line 93 "..\..\Pages\ScheduledJobsPage.cshtml"
                                               Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 94 "..\..\Pages\ScheduledJobsPage.cshtml"
                       Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n                    </td>\r\n                    <t" +
"d class=\"align-right\">\r\n");


            
            #line 98 "..\..\Pages\ScheduledJobsPage.cshtml"
                         if (job.Value.ScheduledAt != null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 100 "..\..\Pages\ScheduledJobsPage.cshtml"
                                          Write(JobHelper.ToStringTimestamp(job.Value.ScheduledAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 101 "..\..\Pages\ScheduledJobsPage.cshtml"
                           Write(job.Value.ScheduledAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n");


            
            #line 103 "..\..\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");


            
            #line 106 "..\..\Pages\ScheduledJobsPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </div>\r\n");


            
            #line 109 "..\..\Pages\ScheduledJobsPage.cshtml"

    
            
            #line default
            #line hidden
            
            #line 110 "..\..\Pages\ScheduledJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 110 "..\..\Pages\ScheduledJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
