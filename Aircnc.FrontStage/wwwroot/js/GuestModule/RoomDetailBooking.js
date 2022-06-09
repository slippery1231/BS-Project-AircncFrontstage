﻿
//room detail page - sticky booking modal - guests number buttons
const minusBtn = document.getElementById('minus')
const addBtn = document.getElementById('add')
const guestNum = document.getElementById('guestNum')

let guestNumValue = Cookies.get('numberOfGuests')
if (guestNumValue != undefined && guestNumValue != NaN) {
    guestNum.setAttribute('value', guestNumValue)
} else {
    guestNum.setAttribute('value', '0')
}

let guestForBooking = guestNum.value

guestNum.addEventListener('keydown', function (e) {
    e.preventDefault()
})

minusBtn.addEventListener('click', function () {
    if (guestForBooking > 0) {
        guestForBooking--
        guestNum.setAttribute('value', guestForBooking)
        Cookies.set('numberOfGuests', guestNum.value)
    }
})

addBtn.addEventListener('click', function () {
    if (guestForBooking < 50) {
        guestForBooking++
        guestNum.setAttribute('value', guestForBooking)
        Cookies.set('numberofGuests', guestNum.value)
    }
})

