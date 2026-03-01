// Chart export utilities — called via Blazor JS interop

window.CosmicExport = {

    // Download SVG element as SVG file
    downloadSvg: function (elementId, fileName) {
        const svgEl = document.getElementById(elementId);
        if (!svgEl) return;
        const serializer = new XMLSerializer();
        const svgStr = serializer.serializeToString(svgEl);
        const blob = new Blob([svgStr], { type: 'image/svg+xml;charset=utf-8' });
        const url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = fileName || 'chart.svg';
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        URL.revokeObjectURL(url);
    },

    // Download a DOM element snapshot as PNG via canvas
    downloadPng: function (elementId, fileName) {
        const el = document.getElementById(elementId);
        if (!el) return;
        // Use html2canvas if available, otherwise convert SVG
        if (window.html2canvas) {
            html2canvas(el, { backgroundColor: '#0d0d1a', scale: 2 }).then(canvas => {
                const link = document.createElement('a');
                link.download = fileName || 'chart.png';
                link.href = canvas.toDataURL('image/png');
                link.click();
            });
        } else {
            // Fallback: convert SVG to canvas
            const svgEl = el.querySelector('svg');
            if (!svgEl) return;
            const serializer = new XMLSerializer();
            const svgStr = serializer.serializeToString(svgEl);
            const img = new Image();
            const svgBlob = new Blob([svgStr], { type: 'image/svg+xml;charset=utf-8' });
            const url = URL.createObjectURL(svgBlob);
            img.onload = function () {
                const canvas = document.createElement('canvas');
                canvas.width = img.width * 2;
                canvas.height = img.height * 2;
                const ctx = canvas.getContext('2d');
                ctx.fillStyle = '#0d0d1a';
                ctx.fillRect(0, 0, canvas.width, canvas.height);
                ctx.scale(2, 2);
                ctx.drawImage(img, 0, 0);
                URL.revokeObjectURL(url);
                const link = document.createElement('a');
                link.download = fileName || 'chart.png';
                link.href = canvas.toDataURL('image/png');
                link.click();
            };
            img.src = url;
        }
    },

    // Persist theme preference
    setTheme: function (theme) {
        document.documentElement.setAttribute('data-theme', theme);
        localStorage.setItem('cosmic-theme', theme);
    },

    getTheme: function () {
        return localStorage.getItem('cosmic-theme') || 'dark';
    }
};
