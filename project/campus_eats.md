# Campus Eats

For the project you will build a bigger version of Campus Eats, hopefully utilising all the different techniques we have used in our lectures. Note that the labs have been intentionally simplified and you cannot necessarily copy code from the labs to the project code.

## Application description

Campus Eats is like Foodora for the campus. Any student on the campus can register as a user, view a menu of items that are available to order, pay for the items and have them brought to the location they specify.

## Work scope

The application has a few different actors with associated workflows. The lists below would be the output of some initial workshops to investigate the domain.  
It should be further refined into various tasks and sub-tasks as part of the project.

The workflows are in a prioritised order, where the top ones are more important than the bottom ones. There are intentionally more work available than the average group is expected to be able to finish, but you are expected to complete a majority of workflows for all actors. You should *not* attempt to finish *all* workflows for one actor before moving on to the next actor, but complete work from the different workflow in a way that makes sense, both for you and for the project. 

There is also a list of technical requirements. The first half of that list must be implemented to get a passing grade.

**The advanced requirements are not necessary to get a passing grade, but to be considered a delivery of very good or excellent performance at least two or three advanced requirements need to be implemented.**

## Actors and workflows

The following actors exist in the system:

### Customer

Person that orders food. We'll need basic contact information like name, phone and email.

#### *Workflows*

* Register as a customer.
* Log on to site.
* Fill out their profile.
* Browse the list of available items.
* Put items in a shopping cart.
* Checkout the cart.
* Pay using an external payment service. (start with simulating this, replace implementation if you're doing the advanced requirement of external payment provider)
* A delivery fee is added to every order.
* View the status of my order (submitted, being picked up, on the way for delivery, delivered, etc).
* Cancel order (if cancelling after accepted by courier, but before pickup, delivery fee is charged, cancelling after pick up is not possible)
* View their order history.
* Ability to tip their courier after delivery.

### Courier

Person that responds to order requests, collects food and deliverers it.

#### *Workflows*

* Log on to the site.
* Registers as a courier on the site. Uses be the same login as a customer, but registering as a courier is a separate action.
* View the status of their pending courier registration. Must be declined/approved by an administrator.
* Through a separate menu option, visible only when logged on as a courier, they can access their dashboard.
* See orders that are available for picking, along with the cost and payment.
* Pick an order and commit to delivering it.
* Mark an order at various status stages (picked up, delivered, etc).
* See history of orders picked/delivered.
* See an overview over earnings so far and month by month. Couriers get 80% of the delivery fee added to every order, plus tip.

### Administrator

Person that administers the site and it's content. The administration site can be a separate application or a separate set of pages and context in the main application. Remember to explain your choice in the report.

#### *Workflows*

* Separate login from the courier/customer
* No self registration, the application should start with a single administrator and a known password.
* The password must be changed on the first login.
* Approves or declines registrations for being a courier.
* Dashboard where they can see the number of orders in their different stages (open, being delivered, delivered). Total and current month-to-date.
* Tool to edit the list of products that can be ordered. Upload picture, change the title, description and price.
* Tool to invite new users to the administration tool.
* Tool to set the delivery fee.
* See how much money has been earned, split with 80 % of the fee to the couriers and 20 % to the service.

## Technical requirements

The application should be a web application

The application should use a form of database.

Customers and couriers should be able to register as a user on our site.

Shopping cart should be persisted across logins until it's removed or checked out.

The application should be able to run from a freshly cloned repository using Docker and docker-compose with a simple batch script or `docker-compose up`.

Using GitHub workflows, automated tests should run on every check-in of code.

The database should be able to be seeded with demo/test data. Including orders in varying states, payments, products, users, etc.  

### Advanced requirements

Password on Self-hosted accounts should be able to self-reset via email.

Customers and couriers should be able to login using various social logins (Google/Microsoft Account, Facebook, Twitter, etc).

The application should have the ability to send emails at certain events:

* Welcome-email after registration
* When your order is picked up
* Delivery confirmation
* Approval/decline of courier registration

  Sending of emails should be done asynchronously by a separate application subscribing to events/queues.

Payment should use a form of external payment service (Stripe, Klarna or similar service that offer a free testing environment).

The customer should be updated about status changes in their delivery though push notifications, and couriers should be notified about new orders through push-notifications.
