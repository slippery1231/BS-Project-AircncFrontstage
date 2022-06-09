let btnSave_room_title = document.querySelector('.room_title');

//==================================================房源照片===========================================
let btnSection_room_img = document.querySelector('.btnSection_room_img');
let edit_room_img_section = document.querySelector('.edit_room_img_section');
let room_img_editSection = document.querySelector('.room_img_editSection');
let btn_edit_room_img = document.getElementById('btn_edit_room_img');
let img_swiper_section = document.querySelector('.img_swiper_section')

let edit_room_imges = document.querySelectorAll('.room_img_container > .edit_room_img');

room_img_editSection.hidden = true;

btn_edit_room_img.addEventListener('click', function () {
    edit_room_img_section.classList.add('edit_room_img_section_after_click_editBtn')
    btn_edit_room_img.hidden = true;
    room_img_editSection.hidden = false;

    ImageDrop();
})

//照片拖拉
function ImageDrop() {

    let room_img_container = document.querySelector('.room_img_container');
    console.log(room_img_container)

    edit_room_imges.forEach((img, i) => {
        //console.log(img)
        img.classList.add(`img${i}`)
        $(img).prop('draggable', true);
        img.addEventListener('dragstart', handleDragStart);
        img.addEventListener('drop', handleDrop);
        img.addEventListener('dragover', CancelDrop);

        img.onclick = function () {

            let t = document.querySelector(`.img${i}`)
            console.log(t)

            var comfirm = window.confirm('確定要刪除照片嗎?')
            if (comfirm) {
                room_img_container.removeChild(t)
            }
        }
    });
}

function RemoveImgDrop() {
    edit_room_imges.forEach(img => {
        $(img).prop('draggable', false);
    });
}

function handleDragStart(e) {

    var index = $(e.target).index();
    //console.log(index);
    e.dataTransfer.setData('text/plain', index);
}


function handleDrop(e) {
    CancelDrop(e);

    let oldIndex = e.dataTransfer.getData('text/plain')
    let target = $(e.target);
    let newIndex = target.index();

    // remove dropped items at old place
    let dropped = $(this).parent().children().eq(oldIndex).remove()
    //console.log($(this).parent());
    //console.log($(this).parent().children());
    //console.log($(this).parent().children().eq(oldIndex));
    //insert the dropped items at new place
    if (newIndex < oldIndex) {
        //console.log(dropped);
        target.before(dropped)
    } else {
        //console.log(dropped);
        target.after(dropped)
    }
    console.log(oldIndex, newIndex);
    return false;
}

function CancelDrop(e) {
    e.stopPropagation();
    e.preventDefault();
    return false;
}

function ChangeRoomImg(result) {
    fetch("/RoomOwner/HostRoomEditRoomImg", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)

        })
}

//==================================================房源標題===========================================
let btnSection_room_title = document.querySelector('.btnSection_room_title'); //房源標題按鈕區塊
let edit_room_title_section = document.querySelector('.edit_room_title_section');
let btn_edit_room_title = document.getElementById('btn_edit_room_title'); //編輯按鈕
let edit_room_title = document.querySelector('.edit_room_title');
let p_edit_room_title_suggestion = document.querySelector('.p_edit_room_title_suggestion');
let input_edit_room_title = document.querySelector('.input_edit_room_title');
let edit_room_title_lenth = document.querySelector('.edit_room_title_lenth');

p_edit_room_title_suggestion.hidden = true;
input_edit_room_title.hidden = true;
edit_room_title_lenth.hidden = true;
btnSection_room_title.setAttribute("style", "display:none!important");

//房源標題編輯按鈕
btn_edit_room_title.addEventListener('click', function () {
    edit_room_title_lenth.innerHTML = input_edit_room_title.value.length + "/50";
    edit_room_title_section.classList.add("edit_room_title_section_after_click_editBtn")
    btn_edit_room_title.setAttribute("style", "display:none");
    edit_room_title.setAttribute("style", "display:none");
    p_edit_room_title_suggestion.hidden = false;
    input_edit_room_title.hidden = false;
    edit_room_title_lenth.hidden = false;
    btnSection_room_title.setAttribute("style", "display:flex");
});

//input_edit_room_title.addEventListener("input", function (event) {
//    btn_save.disabled = false;
//});

input_edit_room_title.addEventListener("keyup", function () {
    edit_room_title_lenth.innerHTML = input_edit_room_title.value.length + "/50"
})

//==========================================房源描述=============================================================
let btnSection_room_description = document.querySelector('.btnSection_room_description'); //房源描述按鈕區塊
let edit_room_description_section = document.querySelector('.edit_room_description_section');
let btn_edit_room_description = document.getElementById('btn_edit_room_description'); //編輯按鈕
let edit_room_description = document.querySelector('.edit_room_description');
let p_edit_room_description_suggestion = document.querySelector('.p_edit_room_description_suggestion');
let textarea_edit_room_description = document.querySelector('.textarea_edit_room_description');
let edit_room_description_lenth = document.querySelector('.edit_room_description_lenth');

p_edit_room_description_suggestion.hidden = true;
textarea_edit_room_description.hidden = true;
edit_room_description_lenth.hidden = true;
btnSection_room_description.setAttribute("style", "display:none!important");

//房源描述編輯按鈕
btn_edit_room_description.addEventListener('click', function () {
    edit_room_description_lenth.innerHTML = textarea_edit_room_description.value.length + "/500";
    edit_room_description_section.classList.add("edit_room_description_section_after_click_editBtn")
    btn_edit_room_description.setAttribute("style", "display:none");
    edit_room_description.setAttribute("style", "display:none");
    p_edit_room_description_suggestion.hidden = false;
    textarea_edit_room_description.hidden = false;
    edit_room_description_lenth.hidden = false;
    btnSection_room_description.setAttribute("style", "display:flex");
});

//textarea_edit_room_description.addEventListener("input", function (event) {
//    btn_save.disabled = false;
//});

textarea_edit_room_description.addEventListener("keyup", function () {
    edit_room_description_lenth.innerHTML = textarea_edit_room_description.value.length + "/500"
})


function ChangeRoomTitle(result) {
    fetch("/RoomOwner/HostRoomEditRoomTitle", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            edit_room_title.innerHTML = jsonData;
            edit_room_title_lenth.innerHTML = jsonData.lenght + "/50"
        })
}

function ChangeRoomDescription(result) {
    fetch("/RoomOwner/HostRoomEditRoomDescription", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            edit_room_description.innerHTML = jsonData;
            edit_room_description_lenth.innerHTML = jsonData.lenght + "/500"
        })
}


//=====================================房源人數編輯===========================================
let edit_room_guestCount = document.querySelector(".edit_room_guestCount");

function btn_edit_guestCount_minus(roomId) {
    let number = parseInt(edit_room_guestCount.textContent)
    let minNum = 0;
    if (number > minNum) {
        number -= 1;
    }
    let GuestCount = {}
    GuestCount.RoomId = roomId;
    GuestCount.GuestCount = number;

    ChangeGuestCount(GuestCount);

}

function btn_edit_guestCount_plus(roomId) {
    let number = parseInt(edit_room_guestCount.textContent)
    let minNum = 0;
    if (number >= minNum) {
        number += 1;
    }
    let GuestCount = {}
    GuestCount.RoomId = roomId;
    GuestCount.GuestCount = number;

    ChangeGuestCount(GuestCount);
}


function ChangeGuestCount(result) {
    fetch("/RoomOwner/HostRoomEditGuestCount", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            edit_room_guestCount.innerHTML = jsonData;
        })
}

//=====================================房源狀態編輯===========================================
//建立中的選項 → 隱藏起來
let room_status_pending = document.querySelector('.select_room_status>option:nth-child(3)')
room_status_pending.hidden = true;

let edit_room_status_section = document.querySelector('.edit_room_status_section');
let btn_edit_room_status = document.getElementById('btn_edit_room_status');
let edit_room_status = document.querySelector('.edit_room_status');
let select_room_status = document.querySelector('.select_room_status')
let room_status_editSection = document.querySelector('.room_status_editSection');
room_status_editSection.hidden = true;

//編輯按鈕
btn_edit_room_status.addEventListener('click', function () {
    edit_room_status_section.classList.add('edit_room_status_section_after__click_editBtn');
    btn_edit_room_status.hidden = true;
    edit_room_status.hidden = true;
    room_status_editSection.hidden = false;
})

function ChangeRoomStatus(result) {
    fetch("/RoomOwner/HostRoomEditRoomStatus", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            edit_room_status.innerHTML = jsonData;
        })
}

//=====================================設備與服務編輯===========================================
let edit_room_equipment_and_service_section = document.querySelector('.edit_room_equipment_and_service_section');
let btn_edit_room_equipment_and_service = document.getElementById('btn_edit_room_equipment_and_service');
let edit_room_equipment_and_service = document.querySelector('.edit_room_equipment_and_service');
let room_equipment_and_service_editSection = document.querySelector('.room_equipment_and_service_editSection');
room_equipment_and_service_editSection.hidden = true;

let i_cross_WiFi = document.querySelector('.i_cross_WiFi');
let i_cross_Kitchen = document.querySelector('.i_cross_廚房');
let i_cross_TV = document.querySelector('.i_cross_電視');
let i_cross_Washing = document.querySelector('.i_cross_洗衣機');
let i_cross_Aircon = document.querySelector('.i_cross_空調');
let i_cross_Parking = document.querySelector('.i_cross_停車位');

let i_check_WiFi = document.querySelector('.i_check_WiFi');
let i_check_Kitchen = document.querySelector('.i_check_廚房');
let i_check_TV = document.querySelector('.i_check_電視');
let i_check_Washing = document.querySelector('.i_check_洗衣機');
let i_check_Aircon = document.querySelector('.i_check_空調');
let i_check_Parking = document.querySelector('.i_check_停車位');

let selecteds = document.querySelectorAll('.selected');
let span_roomService = document.querySelector('.span_roomService');


btn_edit_room_equipment_and_service.addEventListener('click', function () {
    edit_room_equipment_and_service_section.classList.add('edit_room_equipment_and_service_section_after__click_editBtn');
    btn_edit_room_equipment_and_service.hidden = true;
    edit_room_equipment_and_service.hidden = true;
    room_equipment_and_service_editSection.hidden = false;
})

function equipment_and_service_cross(type) {

    switch (type) {
        case 'WiFi':
            i_cross_WiFi.classList.add("cross")
            i_check_WiFi.classList.remove("check")
            break;
        case '廚房':
            i_cross_Kitchen.classList.add("cross")
            i_check_Kitchen.classList.remove("check")
            break;
        case '電視':
            i_cross_TV.classList.add("cross")
            i_check_TV.classList.remove("check")
            break;
        case '洗衣機':
            i_cross_Washing.classList.add("cross")
            i_check_Washing.classList.remove("check")
            break;
        case '空調':
            i_cross_Aircon.classList.add("cross")
            i_check_Aircon.classList.remove("check")
            break;
        case '停車位':
            i_cross_Parking.classList.add("cross")
            i_check_Parking.classList.remove("check")
            break;
    }
}

function equipment_and_service_check(type) {

    switch (type) {
        case 'WiFi':
            i_cross_WiFi.classList.remove("cross")
            i_check_WiFi.classList.add("check")
            break;
        case '廚房':
            i_cross_Kitchen.classList.remove("cross")
            i_check_Kitchen.classList.add("check")
            break;
        case '電視':
            i_cross_TV.classList.remove("cross")
            i_check_TV.classList.add("check")
            break;
        case '洗衣機':
            i_cross_Washing.classList.remove("cross")
            i_check_Washing.classList.add("check")
            break;
        case '空調':
            i_cross_Aircon.classList.remove("cross")
            i_check_Aircon.classList.add("check")
            break;
        case '停車位':
            i_cross_Parking.classList.remove("cross")
            i_check_Parking.classList.add("check")
            break;
    }
}

function ChangeRoomService(result) {
    fetch("/RoomOwner/HostRoomEditRoomService", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            edit_room_equipment_and_service.innerHTML = "";
            let data = jsonData.split("\r\n");
            data.forEach(d => {
                edit_room_equipment_and_service.innerHTML += '<span class="d-block span_roomService">' + d + '</span>';
            });
        })
}


//=====================================房間與空間編輯===========================================
let edit_room_space_section = document.querySelector('.edit_room_space_section');
let room_space_editSection = document.querySelector('.room_space_editSection'); //房源數量相關按鈕區塊
let btn_edit_room_space = document.getElementById('btn_edit_room_space');
let before_edit_roomCount = document.querySelector('.before_edit_roomCount');
let before_edit_bedCount = document.querySelector('.before_edit_bedCount');
let before_edit_bathroomCount = document.querySelector('.before_edit_bathroomCount');

let after_edit_roomCount = document.querySelector('.after_edit_roomCount');
let after_edit_bedCount = document.querySelector('.after_edit_bedCount');
let after_edit_bathroomCount = document.querySelector('.after_edit_bathroomCount');

room_space_editSection.hidden = true;
btn_edit_room_space.addEventListener('click', function () {
    edit_room_space_section.classList.add("edit_room_space_section_after_click_editBtn")
    btn_edit_room_space.hidden = true;
    before_edit_roomCount.hidden = true;
    before_edit_bedCount.hidden = true;
    before_edit_bathroomCount.hidden = true;
    room_space_editSection.hidden = false;
})

let minNum = 0;
function btn_edit_count_minus(type, roomId) {
    switch (type) {
        case 'roomCount':
            let roomNum = parseInt(after_edit_roomCount.textContent);
            if (roomNum > minNum) { roomNum -= 1 };

            let roomCount = {};
            roomCount.RoomId = roomId;
            roomCount.RoomCount = roomNum;

            ChangeRoomCount(roomCount);
            break;
        case 'bedCount':
            let bedNum = parseInt(after_edit_bedCount.textContent);
            if (bedNum > minNum) { bedNum -= 1 };

            let bedCount = {};
            bedCount.RoomId = roomId;
            bedCount.BedCount = bedNum;

            ChangeBedCount(bedCount);
            break;
        case 'bathroomCount':
            let bathroomNum = parseInt(after_edit_bathroomCount.textContent);
            if (bathroomNum > minNum) { bathroomNum -= 1 };

            let bathroomCount = {};
            bathroomCount.RoomId = roomId;
            bathroomCount.BathroomCount = bathroomNum;

            ChangebathroomCount(bathroomCount);
            break;
    }
}

function btn_edit_count_plus(type, roomId) {
    switch (type) {
        case 'roomCount':
            let roomNum = parseInt(after_edit_roomCount.textContent);
            if (roomNum >= minNum) { roomNum += 1 };

            let roomCount = {};
            roomCount.RoomId = roomId;
            roomCount.RoomCount = roomNum;

            ChangeRoomCount(roomCount);
            break;
        case 'bedCount':
            let bedNum = parseInt(after_edit_bedCount.textContent);
            if (bedNum >= minNum) { bedNum += 1 };

            let bedCount = {};
            bedCount.RoomId = roomId;
            bedCount.BedCount = bedNum;

            ChangeBedCount(bedCount);
            break;
        case 'bathroomCount':
            let bathroomNum = parseInt(after_edit_bathroomCount.textContent);
            if (bathroomNum >= minNum) { bathroomNum += 1 };

            let bathroomCount = {};
            bathroomCount.RoomId = roomId;
            bathroomCount.BathroomCount = bathroomNum;

            ChangebathroomCount(bathroomCount);
            break;
    }
}


//=====================================房源類型編輯===========================================
let edit_room_type_section = document.querySelector('.edit_room_type_section');
let btn_edit_room_type = document.getElementById('btn_edit_room_type');
let room_type_editSection = document.querySelector('.room_type_editSection');
let p_room_type = document.querySelector('.p_room_type');

let select_houseType = document.querySelector('.select_houseType')
let select_roomType = document.querySelector('.select_roomType')


room_type_editSection.hidden = true;

//編輯按鈕
btn_edit_room_type.addEventListener('click', function () {
    edit_room_type_section.classList.add('edit_room_type_section_after__click_editBtn');
    btn_edit_room_type.hidden = true;
    p_room_type.hidden = true;
    room_type_editSection.hidden = false;
})

function ChangeRoomType(result) {
    fetch("/RoomOwner/HostRoomEditRoomType", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            p_room_type.innerHTML = '房源類型:' + jsonData;
        })
}

//=======================================================================================
//臥室數量
function ChangeRoomCount(result) {
    fetch("/RoomOwner/HostRoomEditRoomCount", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            after_edit_roomCount.innerHTML = jsonData;
            before_edit_roomCount.innerHTML = '臥室：' + jsonData;
        })
}

//床位數量
function ChangeBedCount(result) {
    fetch("/RoomOwner/HostRoomEditBedCount", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            after_edit_bedCount.innerHTML = jsonData;
            before_edit_bedCount.innerHTML = '床數：' + jsonData;
        })
}

//衛浴數量
function ChangebathroomCount(result) {
    fetch("/RoomOwner/HostRoomEditBathroomCount", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(result)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            after_edit_bathroomCount.innerHTML = jsonData;
            before_edit_bathroomCount.innerHTML = '衛浴：' + jsonData;
        })
}


//取消編輯
function cancelEdit(type) {
    switch (type) {
        case "btnSection_room_img":
            edit_room_img_section.classList.remove('edit_room_img_section_after_click_editBtn')
            btn_edit_room_img.hidden = false;
            room_img_editSection.hidden = true;
            RemoveImgDrop();
            break;
        case "btnSection_room_title":
            edit_room_title_section.classList.remove("edit_room_title_section_after_click_editBtn")
            btn_edit_room_title.setAttribute("style", "display:block");
            edit_room_title.setAttribute("style", "display:block");
            p_edit_room_title_suggestion.hidden = true;
            input_edit_room_title.hidden = true;
            edit_room_title_lenth.hidden = true;
            btnSection_room_title.setAttribute("style", "display:none!important");
            break;

        case "btnSection_room_description":
            edit_room_description_section.classList.remove("edit_room_description_section_after_click_editBtn")
            btn_edit_room_description.setAttribute("style", "display:block");
            edit_room_description.setAttribute("style", "display:block");
            p_edit_room_description_suggestion.hidden = true;
            textarea_edit_room_description.hidden = true;
            edit_room_description_lenth.hidden = true;
            btnSection_room_description.setAttribute("style", "display:none!important");
            break;
        case 'btnSection_room_space':
            edit_room_space_section.classList.remove("edit_room_space_section_after_click_editBtn")
            btn_edit_room_space.hidden = false;
            before_edit_roomCount.hidden = false;
            before_edit_bedCount.hidden = false;
            before_edit_bathroomCount.hidden = false;
            room_space_editSection.hidden = true;
            break;
        case 'btnSection_room_type':
            edit_room_type_section.classList.remove('edit_room_type_section_after__click_editBtn');
            btn_edit_room_type.hidden = false;
            p_room_type.hidden = false;
            room_type_editSection.hidden = true;
            break;
        case 'btnSection_room_status':
            edit_room_status_section.classList.remove('edit_room_status_section_after__click_editBtn');
            btn_edit_room_status.hidden = false;
            edit_room_status.hidden = false;
            room_status_editSection.hidden = true;
            break;
        case 'btnSection_room_equipment_and_service':
            edit_room_equipment_and_service_section.classList.remove('edit_room_equipment_and_service_section_after__click_editBtn');
            btn_edit_room_equipment_and_service.hidden = false;
            edit_room_equipment_and_service.hidden = false;
            room_equipment_and_service_editSection.hidden = true;
            break;
    }
};

//儲存按鈕
function SaveChange(type, roomId) {
    //房源類型
    let selected_houseType_value = select_houseType.options[select_houseType.selectedIndex].value;
    //let selected_houseType_text = select_houseType.options[select_houseType.selectedIndex].text;

    //房間類型
    let selected_roomType_value = select_roomType.options[select_roomType.selectedIndex].value;
    //let selected_roomType_text = select_roomType.options[select_roomType.selectedIndex].text;

    //房源狀態
    let selected_roomStatus_value = select_room_status.options[select_room_status.selectedIndex].value;

    switch (type) {
        case 'room_img':
            edit_room_img_section.classList.remove('edit_room_img_section_after_click_editBtn')
            btn_edit_room_img.hidden = false;
            room_img_editSection.hidden = true;
            let current_room_images = document.querySelectorAll('.room_img_container > .edit_room_img');
            let imgId;
            roomImg = {};
            current_room_images.forEach((img, i) => {
                imgId = img.getAttribute("id").split('_')[1];
                //console.log(imgId);
                roomImg.RoomID = roomId;
                roomImg.RoomImgId = imgId;
                roomImg.Sort = i + 1;
                ChangeRoomImg(roomImg);
            })
            RemoveImgDrop();
            break;
        case "room_title":
            newTitle = input_edit_room_title.value;

            edit_room_title_section.classList.remove("edit_room_title_section_after_click_editBtn")
            btn_edit_room_title.setAttribute("style", "display:block");
            edit_room_title.setAttribute("style", "display:block");
            p_edit_room_title_suggestion.hidden = true;
            input_edit_room_title.hidden = true;
            edit_room_title_lenth.hidden = true;
            btnSection_room_title.setAttribute("style", "display:none!important");

            roomTitle = {};
            roomTitle.RoomID = roomId;
            roomTitle.RoomTitle = newTitle;

            ChangeRoomTitle(roomTitle);
            break;
        case "room_description":
            newDescription = textarea_edit_room_description.value;

            edit_room_description_section.classList.remove("edit_room_description_section_after_click_editBtn")
            btn_edit_room_description.setAttribute("style", "display:block");
            edit_room_description.setAttribute("style", "display:block");
            p_edit_room_description_suggestion.hidden = true;
            textarea_edit_room_description.hidden = true;
            edit_room_description_lenth.hidden = true;
            btnSection_room_description.setAttribute("style", "display:none!important");

            roomDescription = {};
            roomDescription.RoomID = roomId;
            roomDescription.RoomDescription = newDescription;

            ChangeRoomDescription(roomDescription);
            break;
        case "room_space":
            edit_room_space_section.classList.remove("edit_room_space_section_after_click_editBtn")
            btn_edit_room_space.hidden = false;
            before_edit_roomCount.hidden = false;
            before_edit_bedCount.hidden = false;
            before_edit_bathroomCount.hidden = false;
            room_space_editSection.hidden = true;
            break;
        case 'room_type':
            edit_room_type_section.classList.remove('edit_room_type_section_after__click_editBtn');
            btn_edit_room_type.hidden = false;
            p_room_type.hidden = false;
            room_type_editSection.hidden = true;

            editRoomType = {};
            editRoomType.RoomID = roomId;
            editRoomType.HouseType = selected_houseType_value;
            editRoomType.RoomType = selected_roomType_value;

            ChangeRoomType(editRoomType);
            break;
        case 'room_status':
            edit_room_status_section.classList.remove('edit_room_status_section_after__click_editBtn');
            btn_edit_room_status.hidden = false;
            edit_room_status.hidden = false;
            room_status_editSection.hidden = true;

            roomStatus = {};
            roomStatus.RoomId = roomId;
            roomStatus.RoomStatus = selected_roomStatus_value;

            ChangeRoomStatus(roomStatus);
            break;
        case 'room_equipment_and_service':
            edit_room_equipment_and_service_section.classList.remove('edit_room_equipment_and_service_section_after__click_editBtn');
            btn_edit_room_equipment_and_service.hidden = false;
            edit_room_equipment_and_service.hidden = false;
            room_equipment_and_service_editSection.hidden = true;

            serviceResult = [];
            roomService = {};
            roomService.RoomID = roomId;
            selecteds.forEach((item, index) => {
                if (item.classList.contains('check')) {
                    serviceResult.push(index + 1)
                }
            })
            roomService.RoomService = serviceResult;
            console.log(roomService)

            ChangeRoomService(roomService);
            break;
    }

}