using AG2237A1.Data;
using AG2237A1.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-7cc7d9d9-96b4-4b22-a702-167e22a12148
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace AG2237A1.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Customer, CustomerBaseViewModel>();
                cfg.CreateMap<Venue, VenueBaseViewModel>();
                cfg.CreateMap<VenueAddViewModel, Venue>();
                cfg.CreateMap<Venue, VenueEditFormViewModel>();


            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<CustomerBaseViewModel> CustomerGetAll()
        {
            var customers = ds.Customers;
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerBaseViewModel>>(customers);
        }

        public CustomerBaseViewModel CustomerGetById(int id)
        {
            var customer = ds.Customers.Find(id);
            return customer == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(customer);
        }
        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
            var venues = ds.Venues;
            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(venues);
        }

        public VenueBaseViewModel VenueGetById(int id)
        {
            var venues = ds.Venues.Find(id);
            return venues == null ? null : mapper.Map<Venue, VenueBaseViewModel>(venues);
        }

        public VenueBaseViewModel VenueAdd(VenueAddViewModel newVenue)
        {
            //attempt to add the new venue
            var addedVenue = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(newVenue));
            ds.SaveChanges();
            //if successful return the added venue
            return addedVenue == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addedVenue);
        }
        public VenueEditFormViewModel EditVenueGetById(int id)
        {
            var venueEdit = ds.Venues.Find(id);
            return venueEdit == null ? null : mapper.Map<Venue, VenueEditFormViewModel>(venueEdit);
        }

        public VenueEditViewModel VenueEdit(VenueEditFormViewModel updateVenue)
        {
            var updatedVenue = ds.Venues.Find(updateVenue.VenueId);

            updatedVenue.Address = updateVenue.Address;
            updatedVenue.OpenDate = updateVenue.OpenDate;
            updatedVenue.City = updateVenue.City;
            updatedVenue.State = updateVenue.State;
            updatedVenue.Country = updateVenue.Country;
            updatedVenue.PostalCode = updateVenue.PostalCode;
            updatedVenue.Phone = updateVenue.Phone;
            updatedVenue.Fax = updateVenue.Fax;
            updatedVenue.Email = updateVenue.Email;
            updatedVenue.Website = updateVenue.Website;

            ds.SaveChanges();

            return updatedVenue == null ? null : mapper.Map<Venue, VenueEditViewModel>(updatedVenue);
        }
    }
}