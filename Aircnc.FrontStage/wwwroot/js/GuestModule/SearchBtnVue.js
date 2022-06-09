// navigation 搜尋功能
const startDateInput = document.getElementById('startDate')
const endDateInput = document.getElementById('endDate')

let locationCheck = Cookies.get('locationField')
if (locationCheck == undefined) locationCheck = ''

let startDateValue = Cookies.get('navStartDate')
if (startDateValue == undefined) {
    startDateInput.setAttribute('value', '')
} else {
    startDateInput.setAttribute('value', startDateValue)
}
let endDateValue = Cookies.get('navEndDate')
if (endDateValue == undefined) {
    endDateInput.setAttribute('value', '')
} else {
    endDateInput.setAttribute('value', endDateValue)
}

let guestValue = Cookies.get('numberOfGuests')
if (guestValue == '' || guestValue == NaN || guestValue == undefined) guestValue = 0

const navSearch = Vue.createApp ({
    data() {
        return {
            locationField: locationCheck,
            locationErrorMsg: '位置 為必填欄位',
            guests: guestValue,
            btnDisabled: true,
        }
    },
    methods: {
        minusGuests() {
            if (this.guests > 0) {
                this.guests--
            }
        }
    },
    watch: {
        'locationField': {
            immediate: true,
            handler() {
                if (this.locationField == '' || this.locationField == undefined) {
                    this.locationErrorMsg = '位置 為必填欄位'
                    this.btnDisabled = true
                }
                else {
                    this.locationErrorMsg = ''
                    this.btnDisabled = false
                }
                Cookies.set('locationField', this.locationField)
            }
        },
        'guests': {
            handler() {
                Cookies.set('numberOfGuests', this.guests)
            }
        }
    }
})
navSearch.mount('#nav-search')

