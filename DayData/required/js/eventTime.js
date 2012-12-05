$('document').ready(function () {
    $("#starttime, #endtime").timePicker({
        startTime: "12:00 AM",
        endTime: "11:59 PM",
        show24Hours: false,
        separator: ':',
        step: 30
    });
    var oldTime = $.timePicker("#starttime").getTime();
    $("#starttime").change(function () {
        if ($("#endtime").val()) {
            var duration = ($.timePicker("#endtime").getTime() - oldTime);
            var time = $.timePicker("#starttime").getTime();
            $.timePicker("#endtime").setTime(new Date(new Date(time.getTime() + duration)));
            oldTime = time;
        }
    });
    $("#endtime").change(function () {
        if ($.timePicker("#starttime").getTime() > $.timePicker(this).getTime()) {
            $(this).addClass("error");
        }
        else {
            $(this).removeClass("error");
        }
    });
});