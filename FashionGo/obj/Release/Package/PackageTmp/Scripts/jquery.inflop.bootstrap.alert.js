/* global jQuery */
/* jshint globalstrict: true */
"use strict";

if (typeof jQuery === "undefined") {
    throw new Error("jQuery is required");
}

(function($) {
    $.fn.showBootstrapAlertSuccess = function(message, contentType, dissmisable, timeout) {
        return this.showBootstrapAlert({
            message: message,
            contentType: contentType,
            alertType: Bootstrap.AlertType.Success,
            dissmisable: dissmisable,
            timeout: timeout
        });
    };
    $.fn.showBootstrapAlertDanger = function(message, contentType, dissmisable, timeout) {
        return this.showBootstrapAlert({
            message: message,
            contentType: contentType,
            alertType: Bootstrap.AlertType.Danger,
            dissmisable: dissmisable,
            timeout: timeout
        });
    };
    $.fn.showBootstrapAlertWarning = function(message, contentType, dissmisable, timeout) {
        return this.showBootstrapAlert({
            message: message,
            contentType: contentType,
            alertType: Bootstrap.AlertType.Warning,
            dissmisable: dissmisable,
            timeout: timeout
        });
    };
    $.fn.showBootstrapAlertInfo = function(message, contentType, dissmisable, timeout) {
        return this.showBootstrapAlert({
            message: message,
            contentType: contentType,
            alertType: Bootstrap.AlertType.Info,
            dissmisable: dissmisable,
            timeout: timeout
        });
    };
    $.fn.showBootstrapAlert = function(options) {
        var settings = $.extend({
            message: null,
            alertType: Bootstrap.AlertType.None,
            contentType: Bootstrap.ContentType.Text,
            dissmisable: false,
            timeout: 0
        }, options);
        return this.each(function() {
            var ref = $(this);
            ref.empty();
            ref.removeClass();
            var closeBtn = null;
            $(this).addClass(settings.alertType.Background);
            if (settings.dissmisable) {
                closeBtn = $("<button></button>").prop("type", "button").prop("aria-hidden", true).html("&times;").addClass("close").click(function() {
                    ref.hide(200);
                });
                $(this).append(closeBtn);
            }
            if (settings.timeout > 0) {
                setTimeout(function() {
                    ref.hide(200);
                }, settings.timeout);
            }
            var icon = $("<span></span>").prop("aria-hidden", true).addClass(settings.alertType.Icon);
            var alert = $("<div></div>").css("display", "inline").css("margin-left", "5px");
            switch (settings.contentType) {
              case Bootstrap.ContentType.Html:
                alert.html(settings.message).find("a").addClass("alert-link");
                break;

              case Bootstrap.ContentType.Text:
                alert.text(settings.message);
                break;
            }
            $(this).append(icon);
            $(this).append(alert);
            $(this).show();
        });
    };
})(jQuery);

var Bootstrap = {
    AlertType: {
        None: {
            Background: "",
            Icon: ""
        },
        Success: {
            Background: "alert alert-success",
            Icon: "glyphicon glyphicon-ok"
        },
        Info: {
            Background: "alert alert-info",
            Icon: "glyphicon glyphicon-info-sign"
        },
        Warning: {
            Background: "alert alert-warning",
            Icon: "glyphicon glyphicon-alert"
        },
        Danger: {
            Background: "alert alert-danger",
            Icon: "glyphicon glyphicon-exclamation-sign"
        }
    },
    ContentType: {
        Html: "html",
        Text: "text"
    },
    GlyphIcon: {
        Asterisk: "glyphicon glyphicon-asterisk",
        Plus: "glyphicon glyphicon-plus",
        Euro: "glyphicon glyphicon-euro",
        Eur: "glyphicon glyphicon-eur",
        Minus: "glyphicon glyphicon-minus",
        Cloud: "glyphicon glyphicon-cloud",
        Envelope: "glyphicon glyphicon-envelope",
        Pencil: "glyphicon glyphicon-pencil",
        Glass: "glyphicon glyphicon-glass",
        Music: "glyphicon glyphicon-music",
        Search: "glyphicon glyphicon-search",
        Heart: "glyphicon glyphicon-heart",
        Star: "glyphicon glyphicon-star",
        StarEmpty: "glyphicon glyphicon-star-empty",
        User: "glyphicon glyphicon-user",
        Film: "glyphicon glyphicon-film",
        ThLarge: "glyphicon glyphicon-th-large",
        Th: "glyphicon glyphicon-th",
        ThList: "glyphicon glyphicon-th-list",
        Ok: "glyphicon glyphicon-ok",
        Remove: "glyphicon glyphicon-remove",
        ZoomIn: "glyphicon glyphicon-zoom-in",
        ZoomOut: "glyphicon glyphicon-zoom-out",
        Off: "glyphicon glyphicon-off",
        Signal: "glyphicon glyphicon-signal",
        Cog: "glyphicon glyphicon-cog",
        Trash: "glyphicon glyphicon-trash",
        Home: "glyphicon glyphicon-home",
        File: "glyphicon glyphicon-file",
        Time: "glyphicon glyphicon-time",
        Road: "glyphicon glyphicon-road",
        DownloadAlt: "glyphicon glyphicon-download-alt",
        Download: "glyphicon glyphicon-download",
        Upload: "glyphicon glyphicon-upload",
        Inbox: "glyphicon glyphicon-inbox",
        PlayCircle: "glyphicon glyphicon-play-circle",
        Repeat: "glyphicon glyphicon-repeat",
        Refresh: "glyphicon glyphicon-refresh",
        ListAlt: "glyphicon glyphicon-list-alt",
        Lock: "glyphicon glyphicon-lock",
        Flag: "glyphicon glyphicon-flag",
        Headphones: "glyphicon glyphicon-headphones",
        VolumeOff: "glyphicon glyphicon-volume-off",
        VolumeDown: "glyphicon glyphicon-volume-down",
        VolumeUp: "glyphicon glyphicon-volume-up",
        Qrcode: "glyphicon glyphicon-qrcode",
        Barcode: "glyphicon glyphicon-barcode",
        Tag: "glyphicon glyphicon-tag",
        Tags: "glyphicon glyphicon-tags",
        Book: "glyphicon glyphicon-book",
        Bookmark: "glyphicon glyphicon-bookmark",
        Print: "glyphicon glyphicon-print",
        Camera: "glyphicon glyphicon-camera",
        Font: "glyphicon glyphicon-font",
        Bold: "glyphicon glyphicon-bold",
        Italic: "glyphicon glyphicon-italic",
        TextHeight: "glyphicon glyphicon-text-height",
        TextWidth: "glyphicon glyphicon-text-width",
        AlignLeft: "glyphicon glyphicon-align-left",
        AlignCenter: "glyphicon glyphicon-align-center",
        AlignRight: "glyphicon glyphicon-align-right",
        AlignJustify: "glyphicon glyphicon-align-justify",
        List: "glyphicon glyphicon-list",
        IndentLeft: "glyphicon glyphicon-indent-left",
        IndentRight: "glyphicon glyphicon-indent-right",
        FacetimeVideo: "glyphicon glyphicon-facetime-video",
        Picture: "glyphicon glyphicon-picture",
        MapMarker: "glyphicon glyphicon-map-marker",
        Adjust: "glyphicon glyphicon-adjust",
        Tint: "glyphicon glyphicon-tint",
        Edit: "glyphicon glyphicon-edit",
        Share: "glyphicon glyphicon-share",
        Check: "glyphicon glyphicon-check",
        Move: "glyphicon glyphicon-move",
        StepBackward: "glyphicon glyphicon-step-backward",
        FastBackward: "glyphicon glyphicon-fast-backward",
        Backward: "glyphicon glyphicon-backward",
        Play: "glyphicon glyphicon-play",
        Pause: "glyphicon glyphicon-pause",
        Stop: "glyphicon glyphicon-stop",
        Forward: "glyphicon glyphicon-forward",
        FastForward: "glyphicon glyphicon-fast-forward",
        StepForward: "glyphicon glyphicon-step-forward",
        Eject: "glyphicon glyphicon-eject",
        ChevronLeft: "glyphicon glyphicon-chevron-left",
        ChevronRight: "glyphicon glyphicon-chevron-right",
        PlusSign: "glyphicon glyphicon-plus-sign",
        MinusSign: "glyphicon glyphicon-minus-sign",
        RemoveSign: "glyphicon glyphicon-remove-sign",
        OkSign: "glyphicon glyphicon-ok-sign",
        QuestionSign: "glyphicon glyphicon-question-sign",
        InfoSign: "glyphicon glyphicon-info-sign",
        Screenshot: "glyphicon glyphicon-screenshot",
        RemoveCircle: "glyphicon glyphicon-remove-circle",
        OkCircle: "glyphicon glyphicon-ok-circle",
        BanCircle: "glyphicon glyphicon-ban-circle",
        ArrowLeft: "glyphicon glyphicon-arrow-left",
        ArrowRight: "glyphicon glyphicon-arrow-right",
        ArrowUp: "glyphicon glyphicon-arrow-up",
        ArrowDown: "glyphicon glyphicon-arrow-down",
        ShareAlt: "glyphicon glyphicon-share-alt",
        ResizeFull: "glyphicon glyphicon-resize-full",
        ResizeSmall: "glyphicon glyphicon-resize-small",
        ExclamationSign: "glyphicon glyphicon-exclamation-sign",
        Gift: "glyphicon glyphicon-gift",
        Leaf: "glyphicon glyphicon-leaf",
        Fire: "glyphicon glyphicon-fire",
        EyeOpen: "glyphicon glyphicon-eye-open",
        EyeClose: "glyphicon glyphicon-eye-close",
        WarningSign: "glyphicon glyphicon-warning-sign",
        Plane: "glyphicon glyphicon-plane",
        Calendar: "glyphicon glyphicon-calendar",
        Random: "glyphicon glyphicon-random",
        Comment: "glyphicon glyphicon-comment",
        Magnet: "glyphicon glyphicon-magnet",
        ChevronUp: "glyphicon glyphicon-chevron-up",
        ChevronDown: "glyphicon glyphicon-chevron-down",
        Retweet: "glyphicon glyphicon-retweet",
        ShoppingCart: "glyphicon glyphicon-shopping-cart",
        FolderClose: "glyphicon glyphicon-folder-close",
        FolderOpen: "glyphicon glyphicon-folder-open",
        ResizeVertical: "glyphicon glyphicon-resize-vertical",
        ResizeHorizontal: "glyphicon glyphicon-resize-horizontal",
        Hdd: "glyphicon glyphicon-hdd",
        Bullhorn: "glyphicon glyphicon-bullhorn",
        Bell: "glyphicon glyphicon-bell",
        Certificate: "glyphicon glyphicon-certificate",
        ThumbsUp: "glyphicon glyphicon-thumbs-up",
        ThumbsDown: "glyphicon glyphicon-thumbs-down",
        HandRight: "glyphicon glyphicon-hand-right",
        HandLeft: "glyphicon glyphicon-hand-left",
        HandUp: "glyphicon glyphicon-hand-up",
        HandDown: "glyphicon glyphicon-hand-down",
        CircleArrowRight: "glyphicon glyphicon-circle-arrow-right",
        CircleArrowLeft: "glyphicon glyphicon-circle-arrow-left",
        CircleArrowUp: "glyphicon glyphicon-circle-arrow-up",
        CircleArrowDown: "glyphicon glyphicon-circle-arrow-down",
        Globe: "glyphicon glyphicon-globe",
        Wrench: "glyphicon glyphicon-wrench",
        Tasks: "glyphicon glyphicon-tasks",
        Filter: "glyphicon glyphicon-filter",
        Briefcase: "glyphicon glyphicon-briefcase",
        Fullscreen: "glyphicon glyphicon-fullscreen",
        Dashboard: "glyphicon glyphicon-dashboard",
        Paperclip: "glyphicon glyphicon-paperclip",
        HeartEmpty: "glyphicon glyphicon-heart-empty",
        Link: "glyphicon glyphicon-link",
        Phone: "glyphicon glyphicon-phone",
        Pushpin: "glyphicon glyphicon-pushpin",
        Usd: "glyphicon glyphicon-usd",
        Gbp: "glyphicon glyphicon-gbp",
        Sort: "glyphicon glyphicon-sort",
        SortByAlphabet: "glyphicon glyphicon-sort-by-alphabet",
        SortByAlphabetAlt: "glyphicon glyphicon-sort-by-alphabet-alt",
        SortByOrder: "glyphicon glyphicon-sort-by-order",
        SortByOrderAlt: "glyphicon glyphicon-sort-by-order-alt",
        SortByAttributes: "glyphicon glyphicon-sort-by-attributes",
        SortByAttributesAlt: "glyphicon glyphicon-sort-by-attributes-alt",
        Unchecked: "glyphicon glyphicon-unchecked",
        Expand: "glyphicon glyphicon-expand",
        CollapseDown: "glyphicon glyphicon-collapse-down",
        CollapseUp: "glyphicon glyphicon-collapse-up",
        LogIn: "glyphicon glyphicon-log-in",
        Flash: "glyphicon glyphicon-flash",
        LogOut: "glyphicon glyphicon-log-out",
        NewWindow: "glyphicon glyphicon-new-window",
        Record: "glyphicon glyphicon-record",
        Save: "glyphicon glyphicon-save",
        Open: "glyphicon glyphicon-open",
        Saved: "glyphicon glyphicon-saved",
        Import: "glyphicon glyphicon-import",
        Export: "glyphicon glyphicon-export",
        Send: "glyphicon glyphicon-send",
        FloppyDisk: "glyphicon glyphicon-floppy-disk",
        FloppySaved: "glyphicon glyphicon-floppy-saved",
        FloppyRemove: "glyphicon glyphicon-floppy-remove",
        FloppySave: "glyphicon glyphicon-floppy-save",
        FloppyOpen: "glyphicon glyphicon-floppy-open",
        CreditCard: "glyphicon glyphicon-credit-card",
        Transfer: "glyphicon glyphicon-transfer",
        Cutlery: "glyphicon glyphicon-cutlery",
        Header: "glyphicon glyphicon-header",
        Compressed: "glyphicon glyphicon-compressed",
        Earphone: "glyphicon glyphicon-earphone",
        PhoneAlt: "glyphicon glyphicon-phone-alt",
        Tower: "glyphicon glyphicon-tower",
        Stats: "glyphicon glyphicon-stats",
        SdVideo: "glyphicon glyphicon-sd-video",
        HdVideo: "glyphicon glyphicon-hd-video",
        Subtitles: "glyphicon glyphicon-subtitles",
        SoundStereo: "glyphicon glyphicon-sound-stereo",
        SoundDolby: "glyphicon glyphicon-sound-dolby",
        Sound51: "glyphicon glyphicon-sound-5-1",
        Sound61: "glyphicon glyphicon-sound-6-1",
        Sound71: "glyphicon glyphicon-sound-7-1",
        CopyrightMark: "glyphicon glyphicon-copyright-mark",
        RegistrationMark: "glyphicon glyphicon-registration-mark",
        CloudDownload: "glyphicon glyphicon-cloud-download",
        CloudUpload: "glyphicon glyphicon-cloud-upload",
        TreeConifer: "glyphicon glyphicon-tree-conifer",
        TreeDeciduous: "glyphicon glyphicon-tree-deciduous",
        Cd: "glyphicon glyphicon-cd",
        SaveFile: "glyphicon glyphicon-save-file",
        OpenFile: "glyphicon glyphicon-open-file",
        LevelUp: "glyphicon glyphicon-level-up",
        Copy: "glyphicon glyphicon-copy",
        Paste: "glyphicon glyphicon-paste",
        Alert: "glyphicon glyphicon-alert",
        Equalizer: "glyphicon glyphicon-equalizer",
        King: "glyphicon glyphicon-king",
        Queen: "glyphicon glyphicon-queen",
        Pawn: "glyphicon glyphicon-pawn",
        Bishop: "glyphicon glyphicon-bishop",
        Knight: "glyphicon glyphicon-knight",
        BabyFormula: "glyphicon glyphicon-baby-formula",
        Tent: "glyphicon glyphicon-tent",
        Blackboard: "glyphicon glyphicon-blackboard",
        Bed: "glyphicon glyphicon-bed",
        Apple: "glyphicon glyphicon-apple",
        Erase: "glyphicon glyphicon-erase",
        Hourglass: "glyphicon glyphicon-hourglass",
        Lamp: "glyphicon glyphicon-lamp",
        Duplicate: "glyphicon glyphicon-duplicate",
        PiggyBank: "glyphicon glyphicon-piggy-bank",
        Scissors: "glyphicon glyphicon-scissors",
        Bitcoin: "glyphicon glyphicon-bitcoin",
        Btc: "glyphicon glyphicon-btc",
        Xbt: "glyphicon glyphicon-xbt",
        Yen: "glyphicon glyphicon-yen",
        Jpy: "glyphicon glyphicon-jpy",
        Ruble: "glyphicon glyphicon-ruble",
        Rub: "glyphicon glyphicon-rub",
        Scale: "glyphicon glyphicon-scale",
        IceLolly: "glyphicon glyphicon-ice-lolly",
        IceLollyTasted: "glyphicon glyphicon-ice-lolly-tasted",
        Education: "glyphicon glyphicon-education",
        OptionHorizontal: "glyphicon glyphicon-option-horizontal",
        OptionVertical: "glyphicon glyphicon-option-vertical",
        MenuHamburger: "glyphicon glyphicon-menu-hamburger",
        ModalWindow: "glyphicon glyphicon-modal-window",
        Oil: "glyphicon glyphicon-oil",
        Grain: "glyphicon glyphicon-grain",
        Sunglasses: "glyphicon glyphicon-sunglasses",
        TextSize: "glyphicon glyphicon-text-size",
        TextColor: "glyphicon glyphicon-text-color",
        TextBackground: "glyphicon glyphicon-text-background",
        ObjectAlignTop: "glyphicon glyphicon-object-align-top",
        ObjectAlignBottom: "glyphicon glyphicon-object-align-bottom",
        ObjectAlignHorizontal: "glyphicon glyphicon-object-align-horizontal",
        ObjectAlignLeft: "glyphicon glyphicon-object-align-left",
        ObjectAlignVertical: "glyphicon glyphicon-object-align-vertical",
        ObjectAlignRight: "glyphicon glyphicon-object-align-right",
        TriangleRight: "glyphicon glyphicon-triangle-right",
        TriangleLeft: "glyphicon glyphicon-triangle-left",
        TriangleBottom: "glyphicon glyphicon-triangle-bottom",
        TriangleTop: "glyphicon glyphicon-triangle-top",
        Console: "glyphicon glyphicon-console",
        Superscript: "glyphicon glyphicon-superscript",
        Subscript: "glyphicon glyphicon-subscript",
        MenuLeft: "glyphicon glyphicon-menu-left",
        MenuRight: "glyphicon glyphicon-menu-right",
        MenuDown: "glyphicon glyphicon-menu-down",
        MenuUp: "glyphicon glyphicon-menu-up"
    }
};
