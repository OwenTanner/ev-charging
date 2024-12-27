document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('your-name-form');
    const fullNameInput = document.getElementById('full-name');
    const errorMessage = document.getElementById('error-message');
    const continueButton = document.getElementById('continue-button');

    continueButton.addEventListener('click', (event) => {
        
        errorMessage.hidden = true;

        
        if (fullNameInput.value.trim() === '') {
            
            event.preventDefault();

            
            errorMessage.hidden = false;
            fullNameInput.focus();
        } else {
            
            form.submit();
        }
    });
});


document.addEventListener('DOMContentLoaded', () => {
    const emailForm = document.getElementById('emailForm');
    const emailInput = document.getElementById('email');

    if (emailForm) {
        emailForm.addEventListener('submit', (event) => {
            let isValid = true;

            
            const errorMessage = document.getElementById('email-error');
            const errorSummary = document.getElementById('error-message');
            const emailContainer = document.getElementById('email-container');

            errorMessage.style.display = 'none';
            errorSummary.hidden = true;
            emailContainer.classList.remove('govuk-form-group--error');

            
            if (emailInput.value.trim() === '') {
                isValid = false;

                
                errorMessage.style.display = 'block';
                errorMessage.textContent = 'Enter your email address';

                
                emailContainer.classList.add('govuk-form-group--error');

                
                errorSummary.hidden = false;
            }

            
            if (!isValid) {
                event.preventDefault();
                emailInput.focus();
            }
        });
    }
});

document.addEventListener('DOMContentLoaded', () => {
    const vrnForm = document.getElementById('vrnForm'); 
    const vrnInput = document.getElementById('vehicleRegistrationNumber'); 
    const errorMessage = document.getElementById('vehicleRegistrationNumber-error'); 
    const errorSummary = document.getElementById('error-message'); 
    const vrnContainer = document.getElementById('vehicleRegistrationNumber-container'); 

    if (vrnForm) {
        vrnForm.addEventListener('submit', (event) => {
            console.log('VRN form submit button clicked'); 
            let isValid = true;

            
            errorMessage.style.display = 'none';
            errorSummary.hidden = true;
            vrnContainer.classList.remove('govuk-form-group--error');

            
            if (vrnInput.value.trim() === '') {
                console.log('VRN field is empty'); 
                isValid = false;

                
                errorMessage.style.display = 'block';
                errorMessage.textContent = 'Enter your vehicle registration number';

                
                vrnContainer.classList.add('govuk-form-group--error');

                
                errorSummary.hidden = false;
            }

            
            if (!isValid) {
                event.preventDefault(); 
                vrnInput.focus(); 
                console.log('Form submission prevented due to validation errors'); 
            } else {
                console.log('Form is valid, proceeding to the next page'); 
            }
        });
    } else {
        console.error('VRN form not found'); 
    }
});

document.addEventListener('DOMContentLoaded', () => {
    const addressForm = document.getElementById('addressForm');
    const fields = [
        {
            id: 'address-line-1',
            mandatory: true,
            errorMessage: 'Enter your address line 1'
        },
        {
            id: 'address-country',
            mandatory: true,
            errorMessage: 'Country has to be England, Wales, Scotland, or Northern Ireland for this service',
            validate: (value) => ['england', 'wales', 'scotland', 'northern ireland'].includes(value.trim().toLowerCase())
        },
        {
            id: 'address-postcode',
            mandatory: true,
            errorMessage: 'Enter your postcode'
        }
    ];

    if (addressForm) {
        addressForm.addEventListener('submit', (event) => {
            let isValid = true;

            
            const errorSummary = document.getElementById('error-summary');
            const errorSummaryList = document.getElementById('error-summary-list');
            errorSummaryList.innerHTML = '';
            errorSummary.hidden = true;

            fields.forEach(({ id, mandatory, errorMessage, validate }) => {
                const input = document.getElementById(id);
                const errorElement = document.getElementById(`${id}-error`);
                const container = document.getElementById(`${id}-container`);
                const value = input.value.trim();

                
                errorElement.style.display = 'none';
                errorElement.textContent = '';
                container.classList.remove('govuk-form-group--error');

                
                if ((mandatory && value === '') || (validate && !validate(value))) {
                    isValid = false;

                    
                    errorElement.style.display = 'block';
                    errorElement.textContent = errorMessage;

                    
                    container.classList.add('govuk-form-group--error');

                    
                    const errorItem = document.createElement('li');
                    const errorLink = document.createElement('a');
                    errorLink.href = `#${id}`;
                    errorLink.textContent = errorMessage;
                    errorItem.appendChild(errorLink);
                    errorSummaryList.appendChild(errorItem);
                }
            });

            
            if (!isValid) {
                errorSummary.hidden = false;
                event.preventDefault();
            }
        });
    }
});



