public float getReward() {
    var addReward = 0f;
    if (isTurned()) {
        addReward = -0.1f;
    }
    addReward += getAngle() * -0.01f;

    var change = getProgress() - lastProg;
    lastProg = getProgress();
    if (change < 0) change = 0;
    return change + addReward;
}

public float getAngle() {
    var up = center.forward;
    var angle = Vector3.Angle(up, Vector3.up);
    return angle % 90;
}