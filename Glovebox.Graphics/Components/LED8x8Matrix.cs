﻿using Glovebox.Graphics.Drivers;
using Glovebox.Graphics.Grid;
using System;

namespace Glovebox.Graphics.Components {
    public class LED8x8Matrix : Grid8x8, ILedDriver {

        ILedDriver driver;

        public LED8x8Matrix(ILedDriver driver) : base("matrix", driver.PanelsPerDisplay) {
            this.driver = driver;
        }

        public int PanelsPerDisplay {
            get {
                return driver.PanelsPerDisplay;
            }
        }

        public void SetBlinkRate(LedDriver.BlinkRate blinkrate) {
            driver.SetBlinkRate(blinkrate);
        }

        public void SetBrightness(byte level) {
            driver.SetBrightness(level);
        }

        public void SetDisplayState(LedDriver.Display state) {
            driver.SetDisplayState(state);
        }

        public void Write(Pixel[] frame) {
            // never called - implementation is overridden
            throw new NotImplementedException();
        }

        protected override void FrameDraw(Pixel[] frame) {
            driver.Write(frame);
        }
    }
}
