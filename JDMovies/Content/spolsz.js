

inter_pl = {
    cancel: 'Anuluj',
    clear: 'Wyczyść',
    done: 'Ok',
    previousMonth: '‹',
    nextMonth: '›',
    months: [
        'Styczeń',
        'Luty',
        'Marzec',
        'Kwiecień',
        'Maj',
        'Czerwiec',
        'Lipiec',
        'Siepień',
        'Wrzesień',
        'Październik',
        'Listopad',
        'Grudzień'
    ],
    monthsShort: [
        'Sty',
        'Lut',
        'Mar',
        'Kwi',
        'Maj',
        'Cze',
        'Lip',
        'Sie',
        'Wrz',
        'Paź',
        'Lis',
        'Gru'
    ],

    weekdays: [
        'Niedziela',
        'Poniedziałek',
        'Wtorek',
        'Środa',
        'Czwartek',
        'Piątek',
        'Sobota'
    ],

    weekdaysShort: [
        'Niedz.',
        'Pon.',
        'Wt.',
        'Śr.',
        'Cz.',
        'Pt.',
        'Sob.'
    ],

    weekdaysAbbrev: ['N', 'P', 'W', 'Ś', 'C', 'P', 'S']

};

var options = {
    i18n: inter_pl,
};
var elem = document.querySelector('.datepicker');
var instance = M.Datepicker.init(elem, options);