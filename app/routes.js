//
// For guidance on how to create routes see:
// https://prototype-kit.service.gov.uk/docs/create-routes
//

const govukPrototypeKit = require('govuk-prototype-kit')
const router = govukPrototypeKit.requests.setupRouter()



router.post('/ev-answer', function (req, res) {

    
    var regNo = req.session.data['vehicleRegistrationNumber']
    
    if (regNo == "ABC"){
    res.redirect('/deniedev')
    } else {
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
        
        const response = await fetch('http://backend-container:5051/application/submit-form', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(formData)
        });

        console.log(response.status); 
        console.log(await response.text()); 

        if (response.ok) {
            res.redirect('/confirmation'); 
        } else {
            console.error('Failed to submit the form');
            res.status(400).send('Error submitting the form.');
        }
    } catch (error) {
        console.error('Network error:', error);
        res.status(500).send('Error submitting the form. Please try again later.');
    }
});
