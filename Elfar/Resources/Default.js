﻿function window_height(){return $(window).height()*.94}function dialog_resize(){$("#dialog").dialog("option","height",window_height())}$(function(){dialog_resize();$("#show-html").click(dialog_open);$("#tabs").tabs();$(window).resize(dialog_resize)})