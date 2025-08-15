﻿// ==================== ĐỊNH DẠNG NGÀY NHẬP ====================
function initDateInputFormatting() {
    const dateInputIds = ["ngayTuNgay", "ngayDenNgay"];

    dateInputIds.forEach(function (id) {
        const input = document.getElementById(id);
        if (!input) return;

        input.addEventListener("input", function () {
            let value = input.value.replace(/\D/g, "");
            let formatted = "";
            let selectionStart = input.selectionStart;

            if (value.length > 0) formatted += value.substring(0, 2);
            if (value.length >= 3) formatted += "-" + value.substring(2, 4);
            if (value.length >= 5) formatted += "-" + value.substring(4, 8);

            if (formatted !== input.value) {
                const prevLength = input.value.length;
                input.value = formatted;
                const newLength = formatted.length;
                const diff = newLength - prevLength;
                input.setSelectionRange(selectionStart + diff, selectionStart + diff);
            }
        });

        input.addEventListener("click", function () {
            const pos = input.selectionStart;
            if (pos <= 2) input.setSelectionRange(0, 2);
            else if (pos <= 5) input.setSelectionRange(3, 5);
            else input.setSelectionRange(6, 10);
        });

        input.addEventListener("keydown", function (e) {
            const pos = input.selectionStart;
            let val = input.value;

            if (e.key === "Backspace" && (pos === 3 || pos === 6)) {
                e.preventDefault();
                input.value = val.slice(0, pos - 1) + val.slice(pos);
                input.setSelectionRange(pos - 1, pos - 1);
            }
            if (e.key === "Delete" && (pos === 2 || pos === 5)) {
                e.preventDefault();
                input.value = val.slice(0, pos) + val.slice(pos + 1);
                input.setSelectionRange(pos, pos);
            }
        });
    });
}


// ==================== DATEPICKER ====================
function initDatePicker() {
    $('[id="ngayTuNgay"], [id="ngayDenNgay"]').datepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        language: 'vi',
        todayHighlight: true,
        orientation: 'bottom auto',
        weekStart: 1
    });
}

// ==================== BIẾN GLOBAL PHÂN TRANG ====================
let currentPage = 1;
let pageSize = 10;
let totalRecords = 0;
let totalPages = 0;
let isInitialLoad = true;

// ==================== ĐỊNH DẠNG NGÀY XUẤT RA BẢNG ====================
function formatDate(dateString) {
    if (!dateString) return '';
    const date = new Date(dateString);
    if (isNaN(date)) return dateString;
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    return `${day}-${month}-${year}`;
}

// ==================== CẬP NHẬT BẢNG ====================
function updateTable(response) {
    const tbody = $('#data-list');
    tbody.empty();

    console.log("Dữ liệu nhận được:", response);

    if (response.totalRecords !== undefined) {
        totalRecords = response.totalRecords;
        totalPages = response.totalPages;
        currentPage = response.currentPage || 1;
        $('#pageInfo').text(`Trang ${currentPage}/${totalPages} - Tổng ${totalRecords} bản ghi`);
        renderPagination();
    }

    let data = [];
    if (Array.isArray(response)) {
        data = response;
    } else if (response && response.data) {
        data = Array.isArray(response.data) ? response.data : [response.data];
    }

    if (data.length > 0) {
        data.forEach((item, index) => {
            const stt = (currentPage - 1) * pageSize + index + 1;
            const row = `
                <tr>
                    <td>${stt}</td>
                    <td>${item.maYTe || item.MaYTe || ''}</td>
                    <td>${item.maTiepNhan || item.MaTiepNhan || ''}</td>
                    <td style="text-align:left;">${item.hoTen || item.HoTen || 'Không rõ'}</td>
                    <td>${item.namSinh || item.NamSinh || ''}</td>
                    <td>${item.gioiTinh || item.GioiTinh || ''}</td>
                    <td>${item.cccd || item.CCCD || ''}</td>
                    <td>${item.passport || item.Passport || ''}</td>
                    <td>${item.quocTich || item.QuocTich || ''}</td>
                    <td>${item.tenChuyenGia || item.TenChuyenGia || ''}</td>
                    <td style="text-align:left;">${item.goiKham || item.GoiKham || 'Không rõ'}</td>
                    <td>${item.phongKham || item.PhongKham || ''}</td>
                    <td>${formatDate(item.thoiGianTiepNhan || item.thoiGianTiepNhan)}</td>
                    <td>${item.nguoiTiepNhan || item.NguoiTiepNhan || ''}</td>
                    <td style="text-align:left;">${item.TrangThai ? "Đã khám" : "Chưa khám" || ''}</td>

                </tr>
            `;
            tbody.append(row);
        });
    } else {
        tbody.append('<tr><td colspan="8" class="text-center">Không có dữ liệu</td></tr>');
    }
}

// ==================== RENDER PHÂN TRANG ====================
function renderPagination() {
    const pagination = $('#pagination');
    pagination.empty();

    const pages = Math.max(1, totalPages || Math.ceil(totalRecords / pageSize || 1));
    if (currentPage > pages) currentPage = pages;

    $('#pageInfo').text(`Trang ${currentPage}/${pages} - Tổng ${totalRecords} bản ghi`);

    pagination.append(`
        <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
            <a class="page-link" href="#" data-page="${Math.max(1, currentPage - 1)}">Trước</a>
        </li>
    `);

    const visibleCount = 3;
    let startPage = Math.max(1, currentPage - 1);
    let endPage = Math.min(pages, startPage + visibleCount - 1);

    if (endPage - startPage + 1 < visibleCount) {
        startPage = Math.max(1, endPage - visibleCount + 1);
    }

    for (let i = startPage; i <= endPage; i++) {
        pagination.append(`
            <li class="page-item ${i === currentPage ? 'active' : ''}">
                <a class="page-link" href="#" data-page="${i}">${i}</a>
            </li>
        `);
    }

    pagination.append(`
        <li class="page-item ${currentPage === pages ? 'disabled' : ''}">
            <a class="page-link" href="#" data-page="${Math.min(pages, currentPage + 1)}">Sau</a>
        </li>
    `);
}

// ==================== LỌC DỮ LIỆU ====================
function filterData(isPagination = false) {
    const tuNgay = $('#ngayTuNgay').val();
    const denNgay = $('#ngayDenNgay').val();

    if (!isPagination && (!tuNgay || !denNgay)) {
        alert("Vui lòng chọn cả từ ngày và đến ngày");
        return;
    }

    if (!isPagination) {
       
        if (parseDMY(tuNgay) > parseDMY(denNgay)) {
            alert("Từ ngày phải bé hơn đến ngày");
            return;
        }
    }

    $('#loadingSpinner').show();
    $('.table').css('opacity', '0.5');

    $.ajax({
        url: '/benhnhanvip/filter',
        type: 'POST',
        data: {
            tuNgay: tuNgay,
            denNgay: denNgay,
            IdChiNhanh: _idcn,
            page: currentPage,
            pageSize: pageSize
        },
        success: function (response) {
            if (response.success) {
                updateTable(response);
                window.filteredData = Array.isArray(response.data) ? response.data : (response.data ? [response.data] : []);
                totalRecords = response.totalRecords || totalRecords;
                totalPages = response.totalPages || totalPages;
                window.doanhNghiep = response.doanhNghiep || null;
            } else {
                console.error("Có lỗi khi lọc dữ liệu");
            }
        },
        complete: function () {
            $('#loadingSpinner').hide();
            $('.table').css('opacity', '1');
        }
    });
}

// ==================== HÀM HỖ TRỢ LẤY TOÀN BỘ DỮ LIỆU ====================
function ajaxFilterRequest(payload) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/benhnhanvip/filter',
            type: 'POST',
            data: payload,
            success: function (resp) { resolve(resp); },
            error: function (xhr, st, err) { reject(err || st || xhr); }
        });
    });
}

function fetchAllFilteredData(tuNgay, denNgay) {
    return new Promise((resolve, reject) => {
        const basePayload = {
            tuNgay: tuNgay || '',
            denNgay: denNgay || '',
            IdChiNhanh: _idcn,
            page: 1,
            pageSize: pageSize
        };

        ajaxFilterRequest(basePayload).then(firstResp => {
            if (!firstResp || !firstResp.success) {
                reject(firstResp || 'Lỗi khi lấy dữ liệu trang 1');
                return;
            }
            const firstData = Array.isArray(firstResp.data) ? firstResp.data : (firstResp.data ? [firstResp.data] : []);
            const tp = firstResp.totalPages || 1;

            if (tp <= 1) {
                resolve(firstData);
                return;
            }

            const promises = [];
            for (let p = 2; p <= tp; p++) {
                const payload = {
                    tuNgay: tuNgay || '',
                    denNgay: denNgay || '',
                    IdChiNhanh: _idcn,
                    page: p,
                    pageSize: pageSize
                };
                promises.push(ajaxFilterRequest(payload));
            }

            Promise.all(promises)
                .then(results => {
                    const pagesData = results.map(r => Array.isArray(r.data) ? r.data : (r.data ? [r.data] : []));
                    const all = firstData.concat(...pagesData);
                    resolve(all);
                })
                .catch(err => {
                    reject(err);
                });
        }).catch(err => reject(err));
    });
}

// ==================== KIỂM TRA DỮ LIỆU XUẤT ====================
function validateExportDatesAndData() {
    const tuNgay = $('#ngayTuNgay').val();
    const denNgay = $('#ngayDenNgay').val();

    if (!tuNgay && !denNgay) {
        if (!window.filteredData || window.filteredData.length === 0) {
            alert("Không có dữ liệu để xuất");
            return false;
        }
        return true;
    }
    if ((tuNgay && !denNgay) || (!tuNgay && denNgay)) {
        alert("Vui lòng chọn cả từ ngày và đến ngày");
        return false;
    }

    if (parseDMY(tuNgay) > parseDMY(denNgay)) {
        alert("Từ ngày phải nhỏ hơn hoặc bằng đến ngày");
        return false;
    }
    if (!window.filteredData || window.filteredData.length === 0) {
        alert("Không có dữ liệu để xuất");
        return false;
    }
    return true;
}

// ==================== XUẤT EXCEL ====================
function doExportExcel(finalData, btn, originalHtml) {
    const requestData = {
        data: finalData,
        fromDate: $('#ngayTuNgay').val(),
        toDate: $('#ngayDenNgay').val(),
        doanhNghiep: window.doanhNghiep || null
    };

    $.ajax({
        url: '/benhnhanvip/export/excel',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(requestData),
        xhrFields: { responseType: 'blob' },
        success: function (data, status, xhr) {
            const contentType = xhr.getResponseHeader('content-type') || '';
            if (!contentType.includes('spreadsheet') && !contentType.includes('vnd.openxmlformats')) {
                console.error('Tệp trả về không phải Excel');
                return;
            }
            const blob = new Blob([data], { type: contentType });
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = `BaoCaoGoiKham_${requestData.fromDate || 'all'}_den_${requestData.toDate || 'now'}.xlsx`;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        },
        error: function () {
            console.error('Lỗi khi tạo file Excel');
        },
        complete: function () {
            btn.html(originalHtml);
            btn.prop('disabled', false);
        }
    });
}

$('#btnExportExcelGoiKham').off('click').on('click', function (e) {
    e.preventDefault();
    if (!validateExportDatesAndData()) return;

    const btn = $(this);
    const originalHtml = btn.html();
    btn.html('<span class="spinner-border spinner-border-sm"></span> Đang tạo');
    btn.prop('disabled', true);

    const tu = $('#ngayTuNgay').val();
    const den = $('#ngayDenNgay').val();

    if (!window.filteredData || (totalRecords && window.filteredData.length < totalRecords)) {
        fetchAllFilteredData(tu, den)
            .then(allData => {
                window.filteredData = allData;
                doExportExcel(allData, btn, originalHtml);
            })
            .catch(err => {
                console.error('Lỗi khi lấy toàn bộ dữ liệu để xuất:', err);
                btn.html(originalHtml);
                btn.prop('disabled', false);
            });
    } else {
        doExportExcel(window.filteredData, btn, originalHtml);
    }
});

// ==================== XUẤT PDF ====================
function doExportPdf(finalData, btnElem) {
    const requestData = {
        data: finalData,
        fromDate: $('#ngayTuNgay').val(),
        toDate: $('#ngayDenNgay').val(),
        doanhNghiep: window.doanhNghiep || null
    };

    fetch("/benhnhanvip/export/pdf", {
        method: "POST",
        headers: { 'Content-Type': 'application/json', 'Accept': 'application/pdf' },
        body: JSON.stringify(requestData)
    })
        .then(res => {
            if (!res.ok) throw new Error('Network response was not ok');
            return res.blob();
        })
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement("a");
            a.href = url;
            a.download = "BaoCaoGoiKham.pdf";
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(error => {
            console.error("Error:", error);
        })
        .finally(() => {
            btnElem.innerHTML = '<i class="bi bi-file-earmark-pdf"></i> Xuất PDF';
            btnElem.disabled = false;
        });
}

$('#btnExportPDFGoiKham').off('click').on('click', function (e) {
    e.preventDefault();
    if (!validateExportDatesAndData()) return;

    const btn = this;
    btn.innerHTML = '<span class="spinner-border spinner-border-sm"></span> Đang tạo';
    btn.disabled = true;

    const tu = $('#ngayTuNgay').val();
    const den = $('#ngayDenNgay').val();

    if (!window.filteredData || (totalRecords && window.filteredData.length < totalRecords)) {
        fetchAllFilteredData(tu, den)
            .then(allData => {
                window.filteredData = allData;
                doExportPdf(allData, btn);
            })
            .catch(err => {
                console.error('Lỗi khi lấy toàn bộ dữ liệu để xuất PDF:', err);
                btn.innerHTML = '<i class="bi bi-file-earmark-pdf"></i> Xuất PDF';
                btn.disabled = false;
            });
    } else {
        doExportPdf(window.filteredData, btn);
    }
});

// ==================== SỰ KIỆN GIAO DIỆN ====================
$(document).ready(function () {
    initDatePicker();
    initDateInputFormatting();
    bindDateRangeValidation();

});
// ==================== SỰ KIỆN THAY ĐỔI SỐ BẢN GHI MỖI TRANG ====================
$(document).on('change', '#pageSizeSelect', function () {
    pageSize = parseInt($(this).val());
    currentPage = 1;
    filterData();
});

// ==================== SỰ KIỆN PHÂN TRANG ====================
$(document).on('click', '.page-link', function (e) {
    e.preventDefault();
    const page = $(this).data('page');
    if (page >= 1 && page <= totalPages && page !== currentPage) {
        currentPage = page;
        filterData(true);
    }
});
$(document).on('click', '#btnFilter', function (e) {
    e.preventDefault();
    currentPage = 1;
    isInitialLoad = true;
    filterData();
});
// ==================== KIỂM TRA NGÀY BÁO CÁO =================

function bindDateRangeValidation() {
    const $tuNgay = $('#ngayTuNgay');
    const $denNgay = $('#ngayDenNgay');


    function formatDMY(date) {
        const d = String(date.getDate()).padStart(2, '0');
        const m = String(date.getMonth() + 1).padStart(2, '0');
        const y = date.getFullYear();
        return `${d}-${m}-${y}`;
    }

    $tuNgay.on('change', function () {
        const tu = $tuNgay.val();
        const den = $denNgay.val();
        if (tu && den && parseDMY(den) < parseDMY(tu)) {
            $denNgay.val(tu);
        }
    });

    $denNgay.on('change', function () {
        const tu = $tuNgay.val();
        const den = $denNgay.val();
        if (tu && den && parseDMY(den) < parseDMY(tu)) {
            $tuNgay.val(den);
        }
    });
}



// ==================== XỬ LÝ GIAI ĐOẠN =================
    $('#selectGiaiDoan').change(function () {
		const selectedValue = $(this).val();
    const container = $('#selectContainer');
    container.empty();

    if (selectedValue === 'Nam' || selectedValue === 'Ngay') {
        container.css('justify-content', 'flex-start');
		} else if (selectedValue === 'Quy' || selectedValue === 'Thang') {
        container.css('justify-content', 'space-around');
		}

    const currentYear = new Date().getFullYear();
    const currentMonth = new Date().getMonth() + 1;
    const currentQuy = Math.ceil(currentMonth / 3);

    // ======= Dropdown input =======
    function createDropdownInput(id, label, values, defaultValue, onSelect) {
			const html = `
    <div data-dropdown-wrapper style="width: 45%; position: relative;">
        <label class="form-label">${label}</label>
        <input type="text" class="form-control" id="${id}" value="${defaultValue}" autocomplete="off">
            <div id="${id}Dropdown"
                style="display:none; position:absolute; top:100%; left:0; width:100%;
						max-height:200px; overflow-y:auto; z-index:9999; background:white;
						border:1px solid rgba(0,0,0,.15); border-radius:4px;
						box-shadow:0 6px 12px rgba(0,0,0,.175);">
            </div>
    </div>
    `;
    container.append(html);

    const $input = $('#' + id);
    const $dropdown = $('#' + id + 'Dropdown');
    let currentHighlightIndex = -1;

    function highlightCurrentItem() {
		const items = $dropdown.find('.dropdown-item');
        items.removeClass('active bg-primary text-white');
	    if (currentHighlightIndex >= 0 && currentHighlightIndex < items.length) {
            items.eq(currentHighlightIndex).addClass('active bg-primary text-white');

    // Tự động scroll đến item được chọn
        const item = items.eq(currentHighlightIndex)[0];
        if (item) {
            item.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
					}
				}
	}

            function renderList(filter = '') {
                $dropdown.empty();
                currentHighlightIndex = -1;

                const selectedVal = parseInt($input.val(), 10);
                const fallbackVal = defaultValue;
                const selectedOrFallback = Number.isFinite(selectedVal) ? selectedVal : fallbackVal;

                let filteredValues = values.filter(v => !filter || v.toString().includes(filter));

                if (!filteredValues.includes(selectedOrFallback)) {
                    filteredValues.unshift(selectedOrFallback);
                }

                if (filteredValues.length === 0) {
                    $dropdown.append(`<div class="dropdown-item" style="padding:8px 16px; color:#999;"></div>`);
                    return;
                }

                filteredValues.forEach((val, index) => {
                    const isSelected = val === selectedOrFallback;
                    const item = $(`<a href="#" class="dropdown-item ${isSelected ? 'active bg-primary text-white' : ''}"
							data-val="${val}" data-index="${index}"
							style="padding:8px 16px; display:block; text-decoration:none; color:#333; cursor:pointer;">
							${val}</a>`);
                    item.on('click', function (e) {
                        e.preventDefault();
                        selectItem(val);
                    });
                    item.on('mouseenter', function () {
                        currentHighlightIndex = index;
                        highlightCurrentItem();
                    });
                    $dropdown.append(item);
                    if (isSelected) {
                        currentHighlightIndex = index;
                    }
                });

                const items = $dropdown.find('.dropdown-item');
                if (currentHighlightIndex === -1 && items.length) {
                    currentHighlightIndex = 0;
                }
                highlightCurrentItem();
            }

            function selectItem(val) {
                $input.val(val);
                $dropdown.hide();
                if (onSelect) onSelect(val);
            }

            $input.on('focus click', function () {
                renderList();
                $dropdown.show();
            });

            $input.on('input', function () {
                renderList($(this).val());
                $dropdown.show();
            });

            $input.on('keydown', function (e) {
                const items = $dropdown.find('.dropdown-item');
                if (!items.length) return;

                const key = e.key;
                const isUp = key === 'ArrowUp';
                const isDown = key === 'ArrowDown';
                const isEnter = key === 'Enter';
                const isEscape = key === 'Escape';
                const isTab = key === 'Tab';

                if (isUp || isDown || isEnter || isEscape || isTab) {
                    e.preventDefault();
                }

                if (isUp) {
                    currentHighlightIndex = (currentHighlightIndex <= 0) ? items.length - 1 : currentHighlightIndex - 1;
                    highlightCurrentItem();
                    return;
                }

                if (isDown) {
                    currentHighlightIndex = (currentHighlightIndex >= items.length - 1) ? 0 : currentHighlightIndex + 1;
                    highlightCurrentItem();
                    return;
                }

                if (isEnter && currentHighlightIndex >= 0) {
                    const val = parseInt(items.eq(currentHighlightIndex).data('val'), 10);
                    selectItem(val);
                    return;
                }

                if (isEscape) {
                    $dropdown.hide();
                    return;
                }

                if (isTab) {
                    if (currentHighlightIndex >= 0) {
                        const val = parseInt(items.eq(currentHighlightIndex).data('val'), 10);
                        selectItem(val);
                    }
                    return;
                }
            });

            $(document).on('click', function (e) {
                if (!$(e.target).closest('[data-dropdown-wrapper]').length) {
                    $dropdown.hide();
                }
            });
        }

    // ======= Ngày/Tháng/Quý =======
    function formatDate(date) {
	const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    return `${day}-${month}-${year}`;
		}

    function getMonthDateRange(year, month) {
	const startDate = new Date(year, month - 1, 1);
    const endDate = new Date(year, month, 0);
    return {start: startDate, end: endDate };
		}

        function updateDates() {
            const year = parseInt($('#yearInput').val(), 10) || currentYear;

            if (selectedValue === 'Nam') {
                $('#ngayTuNgay').val(`01-01-${year}`);
                $('#ngayDenNgay').val(`31-12-${year}`);
            }
            else if (selectedValue === 'Quy') {
                let quy = parseInt($('#quyInput').val(), 10) || 1;
                if (quy > 4) quy = 4;
                if (quy < 1) quy = 1;

                const startMonth = (quy - 1) * 3 + 1;
                const endMonth = startMonth + 2;
                $('#ngayTuNgay').val(formatDate(new Date(year, startMonth - 1, 1)));
                $('#ngayDenNgay').val(formatDate(new Date(year, endMonth, 0)));
            }
            else if (selectedValue === 'Thang') {
                let month = parseInt($('#thangInput').val(), 10) || currentMonth;
                if (month > 12) month = 12;
                if (month < 1) month = 1;

                const { start, end } = getMonthDateRange(year, month);
                $('#ngayTuNgay').val(formatDate(start));
                $('#ngayDenNgay').val(formatDate(end));
            }

            // Đồng bộ lại datepicker với giá trị mới
            $('#ngayTuNgay').datepicker('setDate', $('#ngayTuNgay').val());
            $('#ngayDenNgay').datepicker('setDate', $('#ngayDenNgay').val());
        }


    // ======= Tạo dropdown =======
    createDropdownInput('yearInput', 'Năm', Array.from({length: currentYear - 1999 }, (_, i) => 2000 + i), currentYear, updateDates);

    if (selectedValue === 'Quy') {
        createDropdownInput('quyInput', 'Quý', [1, 2, 3, 4], currentQuy, updateDates);
		} else if (selectedValue === 'Thang') {
        createDropdownInput('thangInput', 'Tháng', Array.from({ length: 12 }, (_, i) => i + 1), currentMonth, updateDates);
		} else if (selectedValue === 'Ngay') {
        container.empty();
		}

    if (selectedValue !== 'Ngay') {
        updateDates();
		}
	});
//=============== GLOBAL FUNCTION =======================
function parseDMY(s) {
    const parts = s.split('-');
    return new Date(parts[2], parts[1] - 1, parts[0]);
}
