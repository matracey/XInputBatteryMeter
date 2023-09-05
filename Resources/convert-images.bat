@echo off

magick convert -background transparent "svg\WixUIBannerBmp.svg" -layers flatten -resize 493x58 "WixUIBannerBmp.bmp"
magick convert -background transparent "svg\WixUIDialogBmp.svg" -layers flatten -resize 493x312 "WixUIDialogBmp.bmp"
magick convert -background transparent "svg\ControllerIcon.svg" -define icon:auto-resize=16,24,32,48,64,72,96,128,256 "ControllerIcon.ico"

