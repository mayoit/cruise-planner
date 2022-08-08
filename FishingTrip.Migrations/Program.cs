// See https://aka.ms/new-console-template for more information
using FishingTrip.Migrations;
using Microsoft.EntityFrameworkCore;

var factory = new FishingTripPlannerDbContextFactory();
using var context = factory.CreateDbContext(new string[] { });
context.Database.Migrate();
