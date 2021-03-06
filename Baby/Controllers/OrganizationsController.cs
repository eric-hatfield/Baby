﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers
{
	public class OrganizationsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Organizations
		public ActionResult Index()
		{
			var organizations = db.Organizations.OrderBy( o => o.Name );//.Include( o => o.ProcessedBy );
			return View( organizations.ToList() );
		}

		// GET: Organizations/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Organization organization = db.Organizations.Find( id );
			if ( organization == null )
			{
				return HttpNotFound();
			}
			return View( organization );
		}

		// GET: Organizations/Create
		public ActionResult Create()
		{
			ViewBag.ProcessedById = new SelectList( db.Users, "Id", "Surname" );
			return View();
		}

		// POST: Organizations/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "OrganizationId,Name,OfficialOrganizationId,LargeLogo,SmallLogo,WeChatCode,TimeZone,ApplicationSubmissionDate,ApplicationApproveRejectDate,RejectionReason,ProcessedById,Status" )] Organization organization )
		{
			if ( ModelState.IsValid )
			{
				organization.OrganizationId = Guid.NewGuid();
				db.Organizations.Add( organization );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

//			ViewBag.ProcessedById = new SelectList( db.Users, "Id", "Surname", organization.ProcessedById );
			return View( organization );
		}

		// GET: Organizations/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Organization organization = db.Organizations.Find( id );
			if ( organization == null )
			{
				return HttpNotFound();
			}
//			ViewBag.ProcessedById = new SelectList( db.Users, "Id", "Surname", organization.ProcessedById );
			return View( organization );
		}

		// POST: Organizations/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "OrganizationId,Name,OfficialOrganizationId,LargeLogo,SmallLogo,WeChatCode,TimeZone,ApplicationSubmissionDate,ApplicationApproveRejectDate,RejectionReason,ProcessedById,Status" )] Organization organization )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( organization ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
//			ViewBag.ProcessedById = new SelectList( db.Users, "Id", "Surname", organization.ProcessedById );
			return View( organization );
		}

		// GET: Organizations/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Organization organization = db.Organizations.Find( id );
			if ( organization == null )
			{
				return HttpNotFound();
			}
			return View( organization );
		}

		// POST: Organizations/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Organization organization = db.Organizations.Find( id );
			db.Organizations.Remove( organization );
			db.SaveChanges();
			return RedirectToAction( "Index" );
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose( disposing );
		}
	}
}
