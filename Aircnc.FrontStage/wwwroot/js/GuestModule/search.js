//手機版地圖切換(list to map)
//#region
let btnswitchmap = document.querySelector('#btn-switch-map-list')
let roomlist = document.querySelector('.room-list')
let pageNavi = document.querySelector('#pageNavi')
let mapcontainer = document.querySelector('.map-container')

btnswitchmap.addEventListener('click',toRoomList)
function toRoomList(event){
    let target = event.target;
    target.innerHTML = '房源列表';
    target.removeEventListener('click',toRoomList);
    target.addEventListener('click',toMap);
    roomlist.classList.add('d-none');
    roomlist.classList.add('d-md-block');
    pageNavi.classList.add('d-none');
    pageNavi.classList.add('d-md-block');
    mapcontainer.classList.remove('d-none');
    mapcontainer.classList.remove('d-md-block');
}
//#endregion
//手機版地圖切換(map to list)
//#region
function toMap(event){
    let target = event.target;
    target.innerHTML = '地圖';
    target.removeEventListener('click',toMap);
    target.addEventListener('click',toRoomList);
    mapcontainer.classList.add('d-none');
    mapcontainer.classList.add('d-md-block');
    pageNavi.classList.remove('d-none');
    pageNavi.classList.remove('d-md-block');
    roomlist.classList.remove('d-none');
    roomlist.classList.remove('d-md-block');
}
//#endregion


//advenceSearch進階搜尋
const wantToGoGo = document.getElementById('location-field')
const startDateD = document.getElementById('startDate')
const endDateD = document.getElementById('endDate')
const guestNumber = document.getElementById('guestNumbers')
let naviSearch = new Object();
let adSearchVM = new Object();

//每晚預算
//#region
const priceModal = new bootstrap.Modal(document.getElementById('priceModal'));
const minPrice = document.getElementById('minPrice');
const maxPrice = document.getElementById('maxPrice');
const btnpriceClear = document.getElementById('priceClear');
const btnpriceSave = document.getElementById('priceSave');
const priceError = document.getElementById('priceError');
btnpriceClear.addEventListener('click', function () {
    minPrice.value='';
    maxPrice.value = '';
    adSearchVM.minPrice = '';
    adSearchVM.maxPrice = '';
});
btnpriceSave.addEventListener('click', function () {
    if (parseInt(minPrice.value) > parseInt(maxPrice.value)) {
        priceError.classList.remove('invisible');
        priceError.classList.add('visible');
    }
    else {
        adSearchVM.minPrice = parseInt(minPrice.value);
        adSearchVM.maxPrice = parseInt(maxPrice.value);
        priceModal.hide();
    }
    
});
//#endregion
//房源類型
//#region
const houseTypeModal = new bootstrap.Modal(document.getElementById('houseTypeModal'));
const houseTypeClear = document.getElementById('houseTypeClear');
const houseTypeSave = document.getElementById('houseTypeSave');
houseTypeClear.addEventListener('click', function () {
    let checkboxes = document.querySelectorAll('input[name="housetype"]:checked');
    checkboxes.forEach((checkbox) => { checkbox.checked = false });
    let values = [];
    adSearchVM.houseTypes = values;
});
houseTypeSave.addEventListener('click', function () {
    let values = [];
    adSearchVM.houseTypes = values;
    let checkboxes = document.querySelectorAll('input[name="housetype"]:checked');
    checkboxes.forEach((checkbox) => { values.push(checkbox.value) });
    adSearchVM.houseTypes = values;
    houseTypeModal.hide();
})
//#endregion
//房間類型
//#region
const roomTypeModal = new bootstrap.Modal(document.getElementById('roomTypeModal'));
const roomTypeClear = document.getElementById('roomTypeClear');
const roomTypeSave = document.getElementById('roomTypeSave');
roomTypeClear.addEventListener('click', function () {
    let checkboxes = document.querySelectorAll('input[name="roomtype"]:checked');
    checkboxes.forEach((checkbox) => { checkbox.checked = false });
    let values = [];
    adSearchVM.roomTypes = values;
});
roomTypeSave.addEventListener('click', function () {
    let values = [];
    adSearchVM.roomTypes = values;
    let checkboxes = document.querySelectorAll('input[name="roomtype"]:checked');
    checkboxes.forEach((checkbox) => { values.push(checkbox.value) });
    adSearchVM.roomTypes = values;
    roomTypeModal.hide();
})
//#endregion
//臥室床位浴室
//#region
const bedroomModal = new bootstrap.Modal(document.getElementById('bedroomModal'));
const bedroomClear = document.getElementById('bedroomClear');
const bedroomSave = document.getElementById('bedroomSave');
const bedCount = document.getElementById('bed');
const bedroomCount = document.getElementById('bedroom');
const bathroomCount = document.getElementById('bathroom');
const minusBed = document.getElementById('minus-bed');
const minusBedroom = document.getElementById('minus-bedroom');
const minusBathroom = document.getElementById('minus-bathroom');
const addBed = document.getElementById('add-bed');
const addBedroom = document.getElementById('add-bedroom');
const addBathroom = document.getElementById('add-bathroom');
//bed加減
minusBed.addEventListener('click', function () {
    if (parseInt(bedCount.innerText) > 0) {
        bedCount.innerText = parseInt(bedCount.innerText) - 1;
    }
})

addBed.addEventListener('click', function () {
    if (parseInt(bedCount.innerText) < 100) {
        bedCount.innerText = parseInt(bedCount.innerText) + 1;
    }
})
//bedroom加減
minusBedroom.addEventListener('click', function () {
    if (parseInt(bedroomCount.innerText) > 0) {
        bedroomCount.innerText = parseInt(bedroomCount.innerText) - 1;
    }
})

addBedroom.addEventListener('click', function () {
    if (parseInt(bedroomCount.innerText) < 100) {
        bedroomCount.innerText = parseInt(bedroomCount.innerText) + 1;
    }
})
//bathroom加減
minusBathroom.addEventListener('click', function () {
    if (parseInt(bathroomCount.innerText) > 0) {
        bathroomCount.innerText = parseInt(bathroomCount.innerText) - 1;
    }
})

addBathroom.addEventListener('click', function () {
    if (parseInt(bathroomCount.innerText) < 100) {
        bathroomCount.innerText = parseInt(bathroomCount.innerText) + 1;
    }
})

bedroomClear.addEventListener('click', function () {
    bedCount.innerText = "0";
    bedroomCount.innerText = "0";
    bathroomCount.innerText = "0";
});
bedroomSave.addEventListener('click', function () {
    adSearchVM.bedCount = parseInt(bedCount.innerText);
    adSearchVM.roomCount = parseInt(bedroomCount.innerText);
    adSearchVM.bathroomCount = parseInt(bathroomCount.innerText);
    bedroomModal.hide();
    //console.log(adSearchVM)
})
//#endregion
//RoomService and advanceSearchBtn
//#region
const btnAdSearch = document.getElementById('btnAdSearch');
let fetchJsonData;
btnAdSearch.addEventListener('click', function () {
    let values = [];
    adSearchVM.roomServiceLabels = values;
    let checkboxes = document.querySelectorAll('input[name="roomService"]:checked');
    checkboxes.forEach((checkbox) => { values.push(checkbox.value) });
    adSearchVM.roomServiceLabels = values;

    //console.log(values)
    naviSearch.Location = wantToGoGo.value;
    naviSearch.StartDate = startDateD.value;
    naviSearch.EndDate = endDateD.value;
    naviSearch.NumberOfGuests = parseInt(guestNumber.value);

    let searchVM = JSON.stringify({
        NavSearch: naviSearch,
        AdSearch: adSearchVM,
        
    })
    //console.log(searchVM)
    
    fetch("/Search/Search", {
        method: "POST",
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify({ AdQuery: searchVM })
    }).then(response => response.json()
    ).then(jsonData => {
        fetchJsonData = jsonData
        //console.log(fetchJsonData)
        roomListDom(1)
        
    }).catch((error) => {
        console.log(`Error: ${error}`);
    })

})
//#endregion

//由fetch的response生成網頁
//#region
let activePage;
let pages;
function roomListDom(id) {
    //分頁
    activePage = id
    let pageRows = 8; // show rows per page
    let totalRows = fetchJsonData.length;
    pages = 0; //計算總頁數
    if (totalRows % pageRows == 0) {
        pages = totalRows / pageRows;
    }
    else {
        pages = Math.ceil(totalRows / pageRows);
    }
    let startRow = (activePage - 1) * pageRows;
    let showRooms = fetchJsonData.sort(function (a, b) { return b.roomId - a.roomId}).slice(startRow, startRow + 8);
    console.log(showRooms)
    //roomlist前面在手機版地圖切換(list to map)已宣告
    roomlist.innerHTML = ''
    if (totalRows == 0) {
        roomlist.innerHTML = '<p class="fs-3">無任何房源，請重新搜尋。</p>'
    }
    showRooms.forEach((room) => {
        switch (room.houseType) {
            case 1:
                room.houseType = '公寓';
                break;
            case 2:
                room.houseType = '獨棟房屋';
                break;
            case 3:
                room.houseType = '獨特房源';
                break;
            default:
                room.houseType = '家庭式旅館';
                break;
        }
        switch (room.roomType) {
            case 1:
                room.roomType = '整套房源';
                break;
            case 2:
                room.roomType = '獨立房間';
                break;
            default:
                room.roomType = '合住房間';
                break;
        }
        room.roomServiceLabels.forEach((label, index) => {
            switch (label) {
                case 1:
                    room.roomServiceLabels[index] = 'WiFi';
                    break;
                case 2:
                    room.roomServiceLabels[index] = '廚房';
                    break;
                case 3:
                    room.roomServiceLabels[index] = '電視';
                    break;
                case 4:
                    room.roomServiceLabels[index] = '洗衣機';
                    break;
                case 5:
                    room.roomServiceLabels[index] = '空調';
                    break;
                default:
                    room.roomServiceLabels[index] = '停車位';
                    break;
            }
        })
        let row = `<a href="Detail?roomId=${room.roomId}" onmouseover="chbg(${room.roomId})" onmouseout="rcbg(${room.roomId})">
	<div class="card mb-3 mx-3">
		<div class="row g-0">
			<div class="col-md-4 cardImgBox">
				<div id="carouselIndicators-${room.roomId}" class="carousel slide" data-bs-ride="carousel">
					<div class="carousel-indicators">
						<button type="button" data-bs-target="#carouselIndicators-${room.roomId}" data-bs-slide-to="0"
								class="active" aria-current="true" aria-label="Slide 1"></button>
						<button type="button" data-bs-target="#carouselIndicators-${room.roomId}" data-bs-slide-to="1"
								aria-label="Slide 2"></button>
						<button type="button" data-bs-target="#carouselIndicators-${room.roomId}" data-bs-slide-to="2"
								aria-label="Slide 3"></button>
					</div>
					<div class="carousel-inner">
						<div class="carousel-item active">
							<img src="${room.roomImgs[0]}"
								 class="d-block w-100 rounded" alt="${room.roomId}pic1">
						</div>
						<div class="carousel-item">
							<img src="${room.roomImgs[1]}"
								 class="d-block w-100 rounded" alt="${room.roomId}pic2">
						</div>
						<div class="carousel-item">
							<img src="${room.roomImgs[2]}"
								 class="d-block w-100 rounded" alt="${room.roomId}pic3">
						</div>
					</div>
					<button class="carousel-control-prev" type="button"
							data-bs-target="#carouselIndicators-${room.roomId}" data-bs-slide="prev">
						<span class="carousel-control-prev-icon" aria-hidden="true"></span>
						<span class="visually-hidden">Previous</span>
					</button>
					<button class="carousel-control-next" type="button"
							data-bs-target="#carouselIndicators-${room.roomId}" data-bs-slide="next">
						<span class="carousel-control-next-icon" aria-hidden="true"></span>
						<span class="visually-hidden">Next</span>
					</button>
				</div>
			</div>
			<div class="col-md-8">
				<div class="card-body">
					<div>
						<div class="d-flex justify-content-between">
							<p class="card-text mb-0">
								<small class="text-muted">位於 ${room.city} ${room.district} 的 ${room.roomType}</small>
							</p>
							<!-- <input type="checkbox" class="btn-check" id="WishList" autocomplete="off">
							<label class="btn labelHeart" for="WishList" data-bs-toggle="modal"
								   data-bs-target="#WishListModal">
								<i class="far fa-heart"></i>@*<i class="fas fa-heart"></i>*@
							</label> -->

						</div>
						<h5 class="card-title">${room.roomName}</h5>
						<p class="card-text">
							<small class="text-muted">
								${room.pax} 位,${room.roomCount} 間臥室,${room.bedCount} 張床,${room.bathroomCount} 間共用衛浴<br>
								${room.roomServiceLabels.join()}
							</small>
						</p>
					</div>
					<div class="d-flex mt-auto">
						<p class="card-text "><small class="text-muted"><i class="fas fa-star"></i> ${room.stars} (${room.comments} 則評價)</small></p>
						<p class="card-text ms-auto">$ ${room.unitPrice} / 晚</p>
					</div>
				</div>
			</div>
		</div>
	</div>
</a>`
        roomlist.innerHTML += row
    })
    //傳資料給google map生成marker
    rooms = showRooms.map(item => {
        return {
            BathroomCount: item.bathroomCount,
            BedCount: item.bedCount,
            City: item.city,
            Comments: item.comments,
            Country: item.country,
            District: item.district,
            HouseType: item.houseType,
            Lat: item.lat,
            Lng: item.lng,
            Pax: item.pax,
            RoomCount: item.roomCount,
            RoomDescription: item.roomDescription,
            RoomId: item.roomId,
            RoomImgs: item.roomImgs,
            RoomName: item.roomName,
            RoomServiceLabels: item.roomServiceLabels,
            RoomType: item.roomType,
            Stars: item.stars,
            Status: item.status,
            Street: item.street,
            UnitPrice: item.unitPrice,
            UserId: item.userId,
            WishLists:item.wishLists
        }
    })
    //console.log(rooms)
    initMap()
    //生成新的pagination
    let pageNavi = document.getElementById('pageNavi')
    //中間的頁數
    let pageItem = ''
    for (i = 1; i <= pages; i++) {
        let Item = `<li class="page-item ${i == activePage ? 'active' : ''}">
							<a class="page-link" href="javascript: void(0)" aria-label="${i}">${i}</a>
						</li>`
        pageItem += Item
    }
    //向前向後一頁    
    let pagination = `
    <ul class="pagination justify-content-center">
        <li class="page-item">
            <a class="page-link" href="javascript: void(0)" aria-label="Previous">
                &laquo;
            </a>
        </li>
        ${pageItem}
        <li class="page-item">
            <a class="page-link" href="javascript: void(0)" aria-label="Next">
                &raquo;
            </a>
        </li>
    </ul>
    <p class="text-center">第 ${activePage == 1 ? '1' : activePage * 8 - 8} 項至第 ${activePage == pages ? totalRows : activePage * 8} 項，共 ${totalRows} 間房源</p>`
    pageNavi.innerHTML = ''
    pageNavi.innerHTML = pagination

    let pagelink = document.querySelectorAll('.page-link')
    for (i = 0; i < pagelink.length; i++) {
        pagelink[i].addEventListener('click', goPage)
    }
}

function goPage(event) {
    console.log(event.target.getAttribute('aria-label'))
    switch (event.target.getAttribute('aria-label')) {
        case 'Previous':
            activePage == 1 ? '#' : roomListDom(activePage - 1);
            break;
        case 'Next':
            activePage == pages ? '#' : roomListDom(activePage + 1);
            break;
        default:
            roomListDom(event.target.getAttribute('aria-label'));
            break;
    }
}

function goPreviou() {
    activePage == 1 ? null : roomListDom(activePage - 1)
}
function goNext() {
    activePage == pages ? null : roomListDom(activePage + 1)
}

//#endregion
