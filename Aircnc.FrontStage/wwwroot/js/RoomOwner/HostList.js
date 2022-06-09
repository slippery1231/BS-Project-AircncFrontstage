let edit_room_count = document.querySelector('.edit_room_count');
let edit_bed_count = document.querySelector('.edit_bed_count');
let edit_bathroom_count = document.querySelector('.edit_bathroom_count');
let Keyword = document.getElementById('hostList_searchBar');
let wifi = document.getElementById('WiFi');
let Kitchen = document.getElementById('Kitchen');
let TV = document.getElementById('TV');
let Aircon = document.getElementById('Aircon');
let Parking = document.getElementById('Parking');
let Washing = document.getElementById('Washing');
let Online = document.getElementById('Online');
let Offline = document.getElementById('Offline');
let Pending = document.getElementById('Pending');

let btn_dropdown_edit_clear = document.querySelectorAll('.btn_dropdown_edit_clear');

let dropdown_menu_filter_room_count = document.querySelector('.dropdown_menu_filter_room_count');
let dropdown_menu_filter_equipment_and_service = document.querySelector('.dropdown_menu_filter_equipment_and_service');
let dropdown_menu_filter_roomStatus = document.querySelector('.dropdown_menu_filter_roomStatus');

let form_check_equipment_and_service = document.querySelectorAll(
    '.form_check_equipment_and_service>input'
);

let form_check_roomStatus = document.querySelectorAll(
    '.form_check_roomStatus>input'
);

// 減
function room_minus(minusBtn) {
    var count = document.querySelector('.' + minusBtn);
    if (count.textContent > 0) {
        count.textContent -= 1;
    }
}

// 加
function room_plus(plusBtn) {
    var count = document.querySelector('.' + plusBtn);
    count.textContent = parseInt(count.textContent) + 1;
}

//清除btn
function edit_clear(clearType) {

    switch (clearType) {
        case 'clear_room':
            edit_room_count.innerHTML = 0;
            edit_bed_count.innerHTML = 0;
            edit_bathroom_count.innerHTML = 0;
            dropdown_menu_filter_room_count.setAttribute("style", "display:none!important");
            break;
        case 'clear_equipment_and_service':
            form_check_equipment_and_service.forEach((item) =>
                item.checked = false
            );
            dropdown_menu_filter_equipment_and_service.setAttribute("style", "display:none!important");
            break;
        case 'clear_roomStatus':
            form_check_roomStatus.forEach((item) => item.checked = false);
            dropdown_menu_filter_roomStatus.setAttribute("style", "display:none!important");
            break;
        default:
            break;
    }
}


function dropdown_menu_filter(type) {
    switch (type) {
        case 'room_count':
            dropdown_menu_filter_room_count.setAttribute("style","display:block");
            break;
        case 'equipment_and_service':
            dropdown_menu_filter_equipment_and_service.setAttribute("style", "display:block");
            break;
        case 'roomStatus':
            dropdown_menu_filter_roomStatus.setAttribute("style", "display:block");
            break;
        default:
    }
}


function filterBtn(Id) {
    let searchResult = {}
    searchResult.UserId = Id
    //搜尋房源
    searchResult.keyWord = Keyword.value;
    //房間與床鋪
    searchResult.BedCount = parseInt(edit_bed_count.textContent);
    searchResult.BathroomCount = parseInt(edit_bathroom_count.textContent);
    searchResult.RoomCount = parseInt(edit_room_count.textContent);


    //設備與服務
    searchResult.TypeOfLabel = []
    if (Aircon != null && Aircon.checked) {
        searchResult.TypeOfLabel.push(Aircon.value)
    }
    if (Washing != null && Washing.checked) {
        searchResult.TypeOfLabel.push(Washing.value)
    }
    if (wifi != null && wifi.checked) {
        searchResult.TypeOfLabel.push(wifi.value)
    }
    if (Kitchen != null && Kitchen.checked) {
        searchResult.TypeOfLabel.push(Kitchen.value)
    }
    if (Parking != null && Parking.checked) {
        searchResult.TypeOfLabel.push(Parking.value)
    }
    if (TV != null && TV.checked) {
        searchResult.TypeOfLabel.push(TV.value)
    }
    //房源狀態
    searchResult.AllStatus = [];
    if (Online.checked) {
        searchResult.AllStatus.push(Online.value);
    }

    if (Unpublish.checked) {
        searchResult.AllStatus.push(Unpublish.value);
    }

    if (Offline.checked) {
        searchResult.AllStatus.push(Offline.value);
    }
    dropdown_menu_filter_room_count.classList.remove("show");
    dropdown_menu_filter_equipment_and_service.classList.remove("show");
    dropdown_menu_filter_roomStatus.classList.remove("show");


    if (searchResult.keyWord == "" &&
        searchResult.BedCount < 1 &&
        searchResult.BathroomCount < 1 &&
        searchResult.RoomCount < 1 &&
        searchResult.TypeOfLabel.length < 0 &&
        searchResult.AllStatus.length < 0) {
        return alert("請選擇篩選條件");
    }

    dropdown_menu_filter_room_count.setAttribute("style", "display:none!important");
    dropdown_menu_filter_equipment_and_service.setAttribute("style", "display:none!important");
    dropdown_menu_filter_roomStatus.setAttribute("style", "display:none!important");

    console.log(searchResult)
    hostList_search(searchResult);
}


//關鍵字搜尋
function hostList_search(searchResult) {
    fetch("/RoomOwner/HostList", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(searchResult)

    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            // jsonData.forEach(x => {
            //     if (x.status == 1)
            //    {
            //         x.status = `<i class="fas fa-hourglass-half"></i>`

            //     }

            //})
            let tbody = document.querySelector('tbody')
            tbody.innerHTML = ''

            jsonData.forEach(x => {
                let row = `
            <tr class="tr_roomlist w-100">

                <td class="hostList_room_name">
                    <a href="/RoomOwner/HostRoomEditList?roomid=${x.roomId}">
                        <div class="d-flex  host_list_house_img">
                            <img src="${x.imageUrl}">
                            <p class="host_list_house_name">${x.roomName}</p>
                        </div>
                    </a>
                </td>

                <td>
                    ${x.state}
                </td>
                <td><button class="btn">完成</button></td>
                <td><i class="fas fa-check-circle"></i>開</td>
                <td>${x.roomCount}</td>
                <td>${x.bedCount}</td>
                <td>${x.bathroomCount}</td>
                <td>${x.address}</td>
                
                <td>
                    ${new Date(x.createTime).toLocaleString()}
                </td>

            </tr>`
                tbody.innerHTML += row
            })
        })
}