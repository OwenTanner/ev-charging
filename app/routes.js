//
// For guidance on how to create routes see:
// https://prototype-kit.service.gov.uk/docs/create-routes
//

const govukPrototypeKit = require('govuk-prototype-kit')
const router = govukPrototypeKit.requests.setupRouter()



router.post('/ev-answer', function (req, res) {

    // Make a variable and give it the value from 'how-many-balls'
    var regNo = req.session.data['vehicleRegistrationNumber']
  
    // Check whether the variable matches a condition
    if (regNo == "ABC"){
      // Send user to next page
      res.redirect('/deniedev')
    } else {
      // Send user to ineligible page
      res.redirect('/your-email-address')
    }
  
  })

router.post('/submit-form', async (req, res) => {
    console.log('You are on /submit-form'); // Log the request

    // Populate formData with sample data
    const formData = {
        addressLine1: req.session.data['addressLine1'],
        postcode: req.session.data['addressPostcode'],
        fullName: req.session.data['fullName'],
        vehicleRegistrationNumber: req.session.data['vehicleRegistrationNumber'],
        emailAddress: req.session.data['email'],
    };

    try {
        // Post data to the API
        const response = await fetch('http://backend-container:5051/application/submit-form', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(formData)
        });

        console.log(response.status); // Log the response status
        console.log(await response.text()); // Log the response body

        if (response.ok) {
            res.redirect('/confirmation'); // Redirect to confirmation page
        } else {
            console.error('Failed to submit the form');
            res.status(400).send('Error submitting the form.');
        }
    } catch (error) {
        console.error('Network error:', error);
        res.status(500).send('Error submitting the form. Please try again later.');
    }
});
