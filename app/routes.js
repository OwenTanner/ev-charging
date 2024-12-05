//
// For guidance on how to create routes see:
// https://prototype-kit.service.gov.uk/docs/create-routes
//

const govukPrototypeKit = require('govuk-prototype-kit')
const router = govukPrototypeKit.requests.setupRouter()

// Run this code when a form is submitted to 'parking-answer'
router.post('/address-route', function (req, res) {

  // Make a variable and give it the value from 'how-many-balls'
  var country = req.session.data['addressCountry']

  // Check whether the variable matches a condition
  if (!["England", "Scotland", "Northern Ireland", "Wales"].includes(country)){
    // Send user to next page
    res.redirect('/address-error-2a')
  } else {
    // Send user to ineligible page
    res.redirect('/your-name')
  }

})

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