
$(function() {
    
    function fromHEXToRGB(hexString) {
        if (hexString.charAt(0) === '#') {
            hexString = hexString.substr(1);
        }

        if ((hexString.length < 2) || (hexString.length > 6)) {
            return false;
        }

        let values = hexString.split(''),
            r,
            g,
            b;

        if (hexString.length === 2) {
            r = parseInt(values[0].toString() + values[1].toString(), 16);
            g = r;
            b = r;
        } else if (hexString.length === 3) {
            r = parseInt(values[0].toString() + values[0].toString(), 16);
            g = parseInt(values[1].toString() + values[1].toString(), 16);
            b = parseInt(values[2].toString() + values[2].toString(), 16);
        } else if (hexString.length === 6) {
            r = parseInt(values[0].toString() + values[1].toString(), 16);
            g = parseInt(values[2].toString() + values[3].toString(), 16);
            b = parseInt(values[4].toString() + values[5].toString(), 16);

        } else {
            return false;
        }

        return [r, g, b];
    }

    function fromRGBToHSV(rgbParams) {
        const r = rgbParams[0] / 255;
        const g = rgbParams[1] / 255;
        const b = rgbParams[2] / 255;

        const cmax = Math.max(r, Math.max(g, b));
        const cmin = Math.min(r, Math.min(g, b));
        const diff = cmax - cmin;
        let h = -1, s = -1;

        if (cmax == cmin) {
            h = 0;
        } else if (cmax == r) {
            h = (60 * ((g - b) / diff) + 360) % 360;
        } else if (cmax == g) {
            h = (60 * ((b - r) / diff) + 120) % 360; 
        } else if (cmax == b) {
            h = (60 * ((r - g) / diff) + 240) % 360; 
        }

        if (cmax == 0) {
            s = 0;
        } else {
            s = (diff / cmax) * 100;
        }

        const v = cmax * 100;
        return [h, s, v];
    }

    function fromHSVToRGB(hsvParams) {
        let h = hsvParams[0], s = hsvParams[1] / 100, v = hsvParams[2] / 100;
        let r = 0, g = 0, b = 0;
        if (s == 0) {
            r = v, g = v, b = v;
        } else {
            let i, f, p, q, t;

            if (h == 360) {
                h = 0;
            } else {
                h /= 60;
            }

            i = Math.trunc(h);
            f = h - i;

            p = v * (1 - s);
            q = v * (1 - (s * f));
            t = v * (1 - (s * (1 - f)));

            switch (i) {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;

                case 3:
                    r = p;
                    g = q;
                    b = b;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;

                default:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }
        }

        return [Math.trunc(r * 255), Math.trunc(g * 255), Math.trunc(b * 255)];
    }

    function fromLABToRGB(labParams) {
        let y = (labParams[0] + 16) / 116,
        x = labParams[1] / 500 + y,
        z = y - labParams[2] / 200,
        r, g, b;
  
        x = 0.95047 * ((x * x * x > 0.008856) ? x * x * x : (x - 16/116) / 7.787);
        y = 1.00000 * ((y * y * y > 0.008856) ? y * y * y : (y - 16/116) / 7.787);
        z = 1.08883 * ((z * z * z > 0.008856) ? z * z * z : (z - 16/116) / 7.787);
    
        r = x *  3.2406 + y * -1.5372 + z * -0.4986;
        g = x * -0.9689 + y *  1.8758 + z *  0.0415;
        b = x *  0.0557 + y * -0.2040 + z *  1.0570;
    
        r = (r > 0.0031308) ? (1.055 * Math.pow(r, 1/2.4) - 0.055) : 12.92 * r;
        g = (g > 0.0031308) ? (1.055 * Math.pow(g, 1/2.4) - 0.055) : 12.92 * g;
        b = (b > 0.0031308) ? (1.055 * Math.pow(b, 1/2.4) - 0.055) : 12.92 * b;
    
        return [Math.trunc(Math.max(0, Math.min(1, r)) * 255), 
                Math.trunc(Math.max(0, Math.min(1, g)) * 255), 
                Math.trunc(Math.max(0, Math.min(1, b)) * 255)]
    }

    function fromRGBToLAB(rgbParams) {
        let r = rgbParams[0] / 255,
        g = rgbParams[1] / 255,
        b = rgbParams[2] / 255,
        x, y, z;
  
        r = (r > 0.04045) ? Math.pow((r + 0.055) / 1.055, 2.4) : r / 12.92;
        g = (g > 0.04045) ? Math.pow((g + 0.055) / 1.055, 2.4) : g / 12.92;
        b = (b > 0.04045) ? Math.pow((b + 0.055) / 1.055, 2.4) : b / 12.92;
    
        x = (r * 0.4124 + g * 0.3576 + b * 0.1805) / 0.95047;
        y = (r * 0.2126 + g * 0.7152 + b * 0.0722) / 1.00000;
        z = (r * 0.0193 + g * 0.1192 + b * 0.9505) / 1.08883;
    
        x = (x > 0.008856) ? Math.pow(x, 1/3) : (7.787 * x) + 16/116;
        y = (y > 0.008856) ? Math.pow(y, 1/3) : (7.787 * y) + 16/116;
        z = (z > 0.008856) ? Math.pow(z, 1/3) : (7.787 * z) + 16/116;
    
        return [(116 * y) - 16, 500 * (x - y), 200 * (y - z)]
    }

    function updateColorModelValuesFromHEX(hexColor) {
        const rgbParams = fromHEXToRGB(hexColor);
        setRGBParams(rgbParams);
        setHSVParams(fromRGBToHSV(rgbParams));
        setLABParams(fromRGBToLAB(rgbParams));
    }

    function setRGBParams(rgbParams) {
        $('#rgb-red').val(rgbParams[0]);
        $('#rgb-green').val(rgbParams[1]);
        $('#rgb-blue').val(rgbParams[2]);

        $('#rgb-red-slider').slider('value', rgbParams[0]);
        $('#rgb-green-slider').slider('value', rgbParams[1]);
        $('#rgb-blue-slider').slider('value', rgbParams[2]);
    }

    function updateColorModelValuesFromRGB(rgbParams) {
        picker.fire("change", [`rgb(${rgbParams[0]}, ${rgbParams[1]}, ${rgbParams[2]})`], 'without-update');
        setHSVParams(fromRGBToHSV(rgbParams));
        setLABParams(fromRGBToLAB(rgbParams));
    }

    function updateColorModelValuesFromHSV(hsvParams) {
        const rgbParams = fromHSVToRGB(hsvParams);
        picker.fire("change", [`rgb(${rgbParams[0]}, ${rgbParams[1]}, ${rgbParams[2]})`], 'without-update');
        setRGBParams(rgbParams);
        setLABParams(fromRGBToLAB(rgbParams));
    }

    function updateColorModelValuesFromLAB(labParams) {
        const rgbParams = fromLABToRGB(labParams);
        picker.fire("change", [`rgb(${rgbParams[0]}, ${rgbParams[1]}, ${rgbParams[2]})`], 'without-update');
        setRGBParams(rgbParams);
        setHSVParams(fromRGBToHSV(rgbParams));
    }

    function setLABParams(labParams) {
        $('#lab-lightness').val(labParams[0]);
        $('#lab-a').val(labParams[1]);
        $('#lab-b').val(labParams[2]);

        $('#lab-lightness-slider').slider('value', labParams[0]);
        $('#lab-a-slider').slider('value', labParams[1]);
        $('#lab-b-slider').slider('value', labParams[2]);
    }

    function setHSVParams(hsvParams) {
        $('#hsv-hue').val(hsvParams[0]);
        $('#hsv-saturation').val(hsvParams[1]);
        $('#hsv-value').val(hsvParams[2]);

        $('#hsv-hue-slider').slider('value', hsvParams[0]);
        $('#hsv-saturation-slider').slider('value', hsvParams[1]);
        $('#hsv-value-slider').slider('value', hsvParams[2]);
    }

    const picker = new CP(document.querySelector('input#floating-color-picker'));
    picker.on('change', function(color) {
        const hexColor = '#' + color;

        $('.background').css('background-color', hexColor);
        updateColorModelValuesFromHEX(color);
    });

    picker.on('change', function(color) {
        const hexColor = '#' + color;

        $('.background').css('background-color', hexColor);
    }, 'without-update');
    
    $('.rgb-slider').slider({
        min: 0,
        max: 255,
        slide: function(event, ui) {
            const sliderId = $(this).attr('id');
            const inputId = '#' + sliderId.substring(0, sliderId.indexOf('-slider'));
            $(inputId).val(ui.value);

            updateColorModelValuesFromRGB([$('#rgb-red').val(), $('#rgb-green').val(), $('#rgb-blue').val()]);
        }
    });

    $('.hsv-slider').slider({
        min: 0,
        max: 100,
        slide: function(event, ui) {
            const sliderId = $(this).attr('id');
            const inputId = '#' + sliderId.substring(0, sliderId.indexOf('-slider'));

            $(inputId).val(ui.value);
            updateColorModelValuesFromHSV([parseFloat($('#hsv-hue').val()), parseFloat($('#hsv-saturation').val()), parseFloat($('#hsv-value').val())]);
        }
    });
    
    $('.lab-slider').slider({
        min: -128,
        max: 127,
        slide: function(event, ui) {
            const sliderId = $(this).attr('id');
            const inputId = '#' + sliderId.substring(0, sliderId.indexOf('-slider'));

            $(inputId).val(ui.value);
            updateColorModelValuesFromLAB([parseFloat($('#lab-lightness').val()), parseFloat($('#lab-a').val()), parseFloat($('#lab-b').val())]);
        }
    });

    $('#hsv-hue-slider').slider('option', 'max', 360);
    $('#lab-lightness-slider').slider('option', 'min', 0);
    $('#lab-lightness-slider').slider('option', 'max', 100);

    $('.rgb-color-param').on('change', function() {
        const newValue = $(this).val();
        if (newValue < 0) {
            $(this).val(0);
        } else if (newValue > 255) {
            $(this).val(255);
        }

        $('#' + $(this).attr('id') + '-slider').slider('value', $(this).val());
        updateColorModelValuesFromRGB([$('#rgb-red').val(), $('#rgb-green').val(), $('#rgb-blue').val()]);
    });

    $('.hsv-color-param').on('change', function() {
        const sliderId = '#' + $(this).attr('id') + '-slider';

        const newValue = $(this).val();
        $(this).val(Math.max(newValue, $(sliderId).slider('option', 'min')));
        $(this).val(Math.min(newValue, $(sliderId).slider('option', 'max')))

        $(sliderId).slider('value', $(this).val());
        updateColorModelValuesFromHSV([parseFloat($('#hsv-hue').val()), parseFloat($('#hsv-saturation').val()), parseFloat($('#hsv-value').val())]);
    });

    $('.lab-color-param').on('change', function() {
        const sliderId = '#' + $(this).attr('id') + '-slider';

        const newValue = $(this).val();
        $(this).val(Math.max(newValue, $(sliderId).slider('option', 'min')));
        $(this).val(Math.min(newValue, $(sliderId).slider('option', 'max')))

        $(sliderId).slider('value', $(this).val());
        updateColorModelValuesFromLAB([parseFloat($('#lab-lightness').val()), parseFloat($('#lab-a').val()), parseFloat($('#lab-b').val())]);
    });
});


